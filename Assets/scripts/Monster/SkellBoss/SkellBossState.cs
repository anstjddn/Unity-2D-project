using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class SkellBossState : MonoBehaviour
{
    public enum State { Idle, Attack1, Attack2, Attack3, size }
 
    public Transform player;
    private BaseState[] states;
    private State curstate;
    public int Handspeed;
    public Rigidbody2D monsterRb;
    public Animator monsteranim;
    public Collider2D monsterCollider;
    [SerializeField] public GameObject[] handobj;
    [SerializeField] public GameObject Attack1;
    [SerializeField] public Transform[] Attackpoints;
    [SerializeField] public float rotatespeed;




    private void Awake()
    {
        states = new BaseState[(int)State.size];
        states[(int)State.Idle] = new BossIdleState(this);
        states[(int)State.Attack1] = new BossAttack1State(this);
        states[(int)State.Attack2] = new BossAttack2State(this);
        states[(int)State.Attack3] = new BossAttack3State(this);

        monsterRb = GetComponent<Rigidbody2D>();
        monsteranim = GetComponent<Animator>();
        monsterCollider = GetComponent<Collider2D>();
       

    }
   /* private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, );
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }*/

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
   
  
  
}
public class BossIdleState : BaseState           //가만히 있는거
{
    public SkellBossState bossmonster;

    public BossIdleState(SkellBossState bossmonster)
    {
        this.bossmonster = bossmonster;
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
        bossmonster.ChangeState(SkellBossState.State.Attack2);


    }
}
public class BossAttack1State : BaseState             //입에서 회전
{
    public SkellBossState bossmonster;
    public bool isattack;
    public BossAttack1State(SkellBossState bossmonster)
    {
        this.bossmonster = bossmonster;
    }

    public override void Enter()
    {

        bossmonster.monsteranim.SetBool("Attack1", true);
        Debug.Log("Attack1 Enter");
        isattack = false;
    }

    public override void Exit()
    {
        Debug.Log("Attack1 Exit");
        bossmonster.StopCoroutine(AttackRoutin(0f));
    }

    public override void Update()
    {

        Debug.Log("Attack1 Update");
        foreach (Transform t in bossmonster.Attackpoints)
        {
            t.Rotate(-Vector3.back * bossmonster.rotatespeed * Time.deltaTime);
        }

      
        if (!isattack)
        {
            bossmonster.StartCoroutine(AttackRoutin(0.3f));

            
        }
        

    }
    IEnumerator AttackRoutin(float dalay)
    {
        isattack = true;
        foreach (Transform t in bossmonster.Attackpoints)
        {
            SkellBossState.Instantiate(bossmonster.Attack1, t.position, t.rotation);
        }
        yield return new WaitForSeconds(dalay);
       
        isattack = false;
        

    }
}

public class BossAttack2State : BaseState               //손따라가서 레이저
{
    public SkellBossState bossmonster;

    public BossAttack2State(SkellBossState bossmonster)
    {
        this.bossmonster = bossmonster;
    }

    public override void Enter()
    {
        Debug.Log("Attack2 Enter");
    }

    public override void Exit()
    {
        Debug.Log("Attack2 Exit");

    }

    public override void Update()
    {
        /*  GameObject leftobj = bossmonster.handobj[0];
         Debug.Log("Attack2 Update");
         Vector2 playerdir = (bossmonster.player.position - leftobj.transform.position);
       playerdir = new Vector2(0, playerdir.y).normalized;


         leftobj.transform.Translate(new Vector2(0, bossmonster.player.position.y) * 2 * Time.deltaTime);                           //왼쪽손위치추적 
         if(Mathf.Abs(leftobj.transform.position.y - bossmonster.player.position.y)<0.1f)
         {
             leftobj.GetComponent<Animator>().SetBool("Attack", true);
         }*/
        bossmonster.StartCoroutine(Attack2Routin());

    }
    IEnumerator Attack2Routin()
    {
        GameObject leftobj = bossmonster.handobj[0];
        //leftobj.transform.Translate(new Vector2(0, bossmonster.player.position.y) * 2 * Time.deltaTime);                           //왼쪽손위치추적 
        if (Mathf.Abs(leftobj.transform.position.y - bossmonster.player.position.y) > 1f)
        {
            leftobj.transform.Translate(new Vector2(0, bossmonster.player.position.y) * 4 * Time.deltaTime);
            
        }
        else
        {
            leftobj.GetComponent<Animator>().SetBool("Attack", true);
        }
        yield return new WaitForSeconds(1f);
        leftobj.GetComponent<Animator>().SetBool("Attack", false);
        yield return new WaitForSeconds(1f);


        GameObject rightobj = bossmonster.handobj[1];
        //rightobj.transform.Translate(new Vector2(0, bossmonster.player.position.y) * 2 * Time.deltaTime);                           //오른속 공격후 위치추적
        if (Mathf.Abs(rightobj.transform.position.y - bossmonster.player.position.y) < 0.1f)
        {
            rightobj.GetComponent<Animator>().SetBool("Attack", true);
        }
        yield return new WaitForSeconds(3f);
        rightobj.GetComponent<Animator>().SetBool("Attack", false);


    }
}
public class BossAttack3State : BaseState                           //칼 꼿히는거
{
    public SkellBossState bossmonster;

    public BossAttack3State(SkellBossState bossmonster)
    {
        this.bossmonster = bossmonster;
    }

    public override void Enter()
    {
        Debug.Log("Attack3 Enter");
    }

    public override void Exit()
    {
        Debug.Log("Attack3 Exit");

    }

    public override void Update()
    {
        Debug.Log("Attack3 Update");
    }
}



