using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public enum State { Idle,Trace,Attack,size}
    public float detectRange;
    public float AttackRange;

    public Transform Player;
    private BaseState[] states;
    private State curstate;
    public int movespeed;
    public Rigidbody2D monsterRb;
    public Animator monsteranim;
    public Collider2D monsterCollider;
    public SpriteRenderer monsterRender;

    [SerializeField] public GameObject attackpoint;
    [SerializeField] public Vector2 boxsize;
    [SerializeField] public LayerMask attackable;
    [SerializeField] public int damage;



    private void Awake()
    {
        states = new BaseState[(int)State.size];
        states[(int)State.Idle] = new IdleState(this);
        states[(int)State.Trace] = new TraceState(this);
        states[(int)State.Attack] = new AttackState(this);

        monsterRb = GetComponent<Rigidbody2D>();
        monsteranim = GetComponent<Animator>();
        monsterCollider = GetComponent<Collider2D>();
        monsterRender = GetComponent<SpriteRenderer>();
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackpoint.transform.position, boxsize);
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        curstate = State.Idle;
        states[(int)curstate].Enter();
    }
    private void Update()
    {
        states[(int)curstate].Update();
      
    }

    public void ChangeState(State state)
    {
        states[(int)curstate].Exit();
        curstate = state;
        states[(int)curstate].Enter();
    }
    public void checkd()
    {
        if (Vector2.Distance(Player.position, transform.position) < detectRange)
        {
            ChangeState(State.Trace);
        }
        if (Vector2.Distance(Player.position, transform.position) < AttackRange)
        {
            ChangeState(State.Attack);
        }
    }
    
}

public class IdleState : BaseState
{
    public Monster monster;

    public IdleState(Monster monster)
    {
        this.monster = monster;
    }

    public override void Enter()
    {
        Debug.Log("Idle Enter");
    }

    public override void Exit()
    {
        Debug.Log("Idle Exit");

    }

    public override void Update()
    {
        Debug.Log("Idle Update");
        if (Vector2.Distance(monster.Player.position, monster.transform.position) < monster.detectRange)
        {
            monster.ChangeState(Monster.State.Trace);
        }
        

    }
}
public class TraceState : BaseState
{
    public Monster monster;

    public TraceState(Monster monster)
    {
        this.monster = monster;
    }
    public override void Enter()
    {
        Debug.Log("Trace Enter");
    }

    public override void Exit()
    {
        Debug.Log("Trace Exit");
        monster.monsteranim.SetBool("Move", false);
    }

    public override void Update()
    {
        Debug.Log("Trace Update");
        Vector2 playerdir = (monster.Player.position-monster.transform.position);
        playerdir = new Vector2(playerdir.x, 0).normalized;
        monster.transform.Translate(playerdir * monster.movespeed * Time.deltaTime);
        monster.monsteranim.SetBool("Move", true);

        if (Vector2.Distance(monster.Player.position, monster.transform.position) < monster.AttackRange)
        {
            monster.ChangeState(Monster.State.Attack);
        }
      
        if((monster.Player.transform.position.x-monster.transform.position.x)< 0) //플레이어 왼쪽
        {
            monster.monsterRender.flipX = true;
        }
        else
        {
            monster.monsterRender.flipX = false; 
        }
        
        
    }
}

public class AttackState : BaseState
{
    public Monster monster;

    public AttackState(Monster monster)
    {
        this.monster = monster;
    }
    public override void Enter()
    {

        monster.monsteranim.SetTrigger("Attack");
        Debug.Log("Attack Enter");
        monster.StartCoroutine(AttackRoutin());

    }

    public override void Exit()
    {
        Debug.Log("Attack Exit");

    }

    public override void Update()
    {
        Debug.Log("Attack Update");
        

    }

    IEnumerator AttackRoutin()
    {
        
        Collider2D[] colliders = Physics2D.OverlapBoxAll(monster.attackpoint.transform.position, monster.boxsize, 0, monster.attackable);
        foreach (Collider2D collider in colliders)
        {
            
            IHitable hitable = collider.GetComponent<IHitable>();
            
            hitable.TakeHit(monster.damage);
            
        }
        yield return new WaitForSeconds(1f);
    }
}