using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] GameObject[] handobj;
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
        bossmonster.ChangeState(SkellBossState.State.Attack1);


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


        /*  bossmonster.monsteranim.SetBool("Attack1", true);
          GameObject leftobj = new GameObject();
          leftobj.name = "Attackleft";
          leftobj.transform.parent = bossmonster.Attackpoint;
          leftobj.transform.position = bossmonster.Attackpoint.position;


          GameObject righttobj = new GameObject();
          righttobj.name = "AttackRight";
          righttobj.transform.parent = bossmonster.Attackpoint;
          righttobj.transform.position = bossmonster.Attackpoint.position;
          righttobj.transform.Rotate(0, 0, 180);




          GameObject Upobj = new GameObject();
          Upobj.name = "AttackUp";
          Upobj.transform.parent = bossmonster.Attackpoint;
          Upobj.transform.position = bossmonster.Attackpoint.position;
          Upobj.transform.Rotate(0, 0, 90);



          GameObject Downobj = new GameObject();
          Downobj.name = "AttackDown";
          Downobj.transform.parent = bossmonster.Attackpoint;
          Downobj.transform.position = bossmonster.Attackpoint.position;
          Downobj.transform.Rotate(0, 0, 270);*/

        //SkellBossState.Instantiate(bossmonster.Attack1, bossmonster.Attackpoint.position,Quaternion.identity);


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

        //SkellBossState.Instantiate(bossmonster.Attack1, bossmonster.Attackpoint.position, bossmonster.Attackpoint.rotation); //한쪽만 회전
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
        
    }

    public override void Exit()
    {
        Debug.Log("Idle Exit");

    }

    public override void Update()
    {

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
        Debug.Log("Idle Enter");
    }

    public override void Exit()
    {
        Debug.Log("Idle Exit");

    }

    public override void Update()
    {

    }
}



