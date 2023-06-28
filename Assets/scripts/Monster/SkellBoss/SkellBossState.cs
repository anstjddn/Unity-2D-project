using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
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


    [SerializeField] public GameObject[] Attack3point;
    [SerializeField] public GameObject Attack3prefabs;
    

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

    public void TakeHit(int dagame)
    {
        throw new System.NotImplementedException();
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
        bossmonster.ChangeState(SkellBossState.State.Attack3);


    }
}
public class BossAttack1State : BaseState             //입에서 회전
{
    public SkellBossState bossmonster;
    public bool isattack;
    public int curTime = 0;
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
        bossmonster.StopAllCoroutines();
    }

    public override void Update()
    {
        float curTime = 0;
        curTime += Time.deltaTime;
       
        if (!isattack)
        {
            bossmonster.StartCoroutine(AttackRoutin(0.4f));

        }
        Debug.Log("Attack1 Update");
        foreach (Transform t in bossmonster.Attackpoints)
        {
            t.Rotate(-Vector3.back * bossmonster.rotatespeed * Time.deltaTime);
           
        }
        if (curTime > 8f)
        {

            bossmonster.StopAllCoroutines();
            bossmonster.ChangeState(SkellBossState.State.Attack3);

        }


        /* if (!isattack)
         {
             bossmonster.StartCoroutine(AttackRoutin(0.4f));

         }*/


    }
    IEnumerator AttackRoutin(float dalay)
    {
       
        isattack = true;
        if (isattack)
        {
            foreach (Transform t in bossmonster.Attackpoints)
            {
                SkellBossState.Instantiate(bossmonster.Attack1, t.position, t.rotation);
            }
            
        }
        yield return new WaitForSeconds(dalay);
      
        isattack = false;
      

    }
    
}

public class BossAttack2State : BaseState               //손따라가서 레이저
{
    public SkellBossState bossmonster;
    private bool isAttack2left;
    private bool isAttack2right;
    private bool isAttack2end;
    private bool isAttack2last;


    public BossAttack2State(SkellBossState bossmonster)
    {
        this.bossmonster = bossmonster;


    }

    public override void Enter()
    {

        Debug.Log("Attack2 Enter");
        isAttack2left = false;
        isAttack2right = false;
        isAttack2end = false;

    }

    public override void Exit()
    {
        Debug.Log("Attack2 Exit");
    }

    public override void Update()
    {

        bossmonster.StartCoroutine(Attack2Routin());

        if (isAttack2last)
        {
            bossmonster.StopAllCoroutines();
            bossmonster.ChangeState(SkellBossState.State.Attack1);
        }


    }
    IEnumerator Attack2Routin()
    {
        GameObject leftobj = bossmonster.handobj[0];
        GameObject rightobj = bossmonster.handobj[1];
        GameObject leftlayer = leftobj.transform.GetChild(0).gameObject;
        GameObject rightlayer = rightobj.transform.GetChild(0).gameObject;

        if (Mathf.Abs(bossmonster.player.position.y - leftobj.transform.position.y) > 0.1f && !isAttack2left)
        {
            Vector2 playerdirleft = (bossmonster.player.position - leftobj.transform.position);
            playerdirleft = new Vector2(0, playerdirleft.y).normalized;
            leftobj.transform.Translate(playerdirleft * 4 * Time.deltaTime);

        }

        if (Mathf.Abs(leftobj.transform.position.y - bossmonster.player.position.y) < 0.1f && !isAttack2left)
        {

            leftobj.transform.Translate(Vector3.zero);

            leftobj.GetComponent<Animator>().SetBool("Attack", true);
            isAttack2left = true;
            yield return new WaitForSeconds(0.8f);
            leftlayer.SetActive(true);
            leftobj.GetComponent<Animator>().SetBool("Attack", false);
            yield return new WaitForSeconds(1f);
            leftlayer.SetActive(false);
        }
        if (Mathf.Abs(leftobj.transform.position.y - bossmonster.player.position.y) < 0.3f && isAttack2left)
        {
            //데미지 받은거 구현

        }

            yield return new WaitForSeconds(1.5f);   //왼손쓰고 1초후 오른손

            if (Mathf.Abs(rightobj.transform.position.y - bossmonster.player.position.y) > 0.1f && !isAttack2right)
            {

                Vector2 playerdirRight = (bossmonster.player.position - rightobj.transform.position);
                playerdirRight = new Vector2(0, playerdirRight.y).normalized;
                rightobj.transform.Translate(playerdirRight * 4 * Time.deltaTime);

            }


            if (Mathf.Abs(rightobj.transform.position.y - bossmonster.player.position.y) < 0.1f && !isAttack2right)
            {


                rightobj.transform.Translate(Vector3.zero);
                isAttack2right = true;
                rightobj.GetComponent<Animator>().SetBool("righthand", true);
                yield return new WaitForSeconds(0.8f);
                rightlayer.SetActive(true);
                rightobj.GetComponent<Animator>().SetBool("righthand", false);
                yield return new WaitForSeconds(1f);
                rightlayer.SetActive(false);

            }

            yield return new WaitForSeconds(1.5f);

            if (Mathf.Abs(leftobj.transform.position.y - bossmonster.player.position.y) > 0.1f && !isAttack2last)
            {
                Vector2 playerdirleft = (bossmonster.player.position - leftobj.transform.position);
                playerdirleft = new Vector2(0, playerdirleft.y).normalized;
                leftobj.transform.Translate(playerdirleft * 4 * Time.deltaTime);

            }

            if (Mathf.Abs(leftobj.transform.position.y - bossmonster.player.position.y) < 0.1f && !isAttack2last)
            {
                leftobj.transform.Translate(Vector3.zero);

                leftobj.GetComponent<Animator>().SetBool("Attack", true);
                yield return new WaitForSeconds(0.8f);
                leftlayer.SetActive(true);
                leftobj.GetComponent<Animator>().SetBool("Attack", false);
                isAttack2last = true;
                yield return new WaitForSeconds(1f);
                leftlayer.SetActive(true);

            }
            yield return new WaitForSeconds(7f);

        }
     
    }
    public class BossAttack3State : BaseState                           //칼 꼿히는거
    {
        public SkellBossState bossmonster;
         private bool Attack3path= false;
         private bool Attack3a= false;
         private bool Attack3b = false;
         private bool Attack3c = false;
         private bool Attack3d = false;
         private bool Attack3e = false;
         private bool Attack3f = false;
         GameObject attack3obj1;
         GameObject attack3obj2;
         GameObject attack3obj3;
         GameObject attack3obj4;
         GameObject attack3obj5;
         GameObject attack3obj6;
         public Vector2 targetDir;
         public bool playerchehck = false;

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
        bossmonster.StartCoroutine(Attack3routin());
    }

    IEnumerator Attack3routin()
    {
        /*if (!Attack3path)
         {
             foreach (GameObject attackobjs in bossmonster.Attack3point)
             {

                 SkellBossState.Instantiate(bossmonster.Attack3prefabs, attackobjs.transform.position, Quaternion.identity);

             }
             Attack3path = true;
         }
         yield return new WaitForSeconds(2f);*/
     
        if (!Attack3path && !Attack3a)
        {
            attack3obj1 = SkellBossState.Instantiate(bossmonster.Attack3prefabs, bossmonster.Attack3point[0].transform.position, Quaternion.identity);
          
            Attack3a = true;
        }
        yield return new WaitForSeconds(0.5f);
        if(!Attack3path && !Attack3b)
        {
            attack3obj2 = SkellBossState.Instantiate(bossmonster.Attack3prefabs, bossmonster.Attack3point[1].transform.position, Quaternion.identity);
            Attack3b = true;
        }
        yield return new WaitForSeconds(0.5f);
        if (!Attack3path && !Attack3c)
        {
            attack3obj3 = SkellBossState.Instantiate(bossmonster.Attack3prefabs, bossmonster.Attack3point[2].transform.position, Quaternion.identity);
            Attack3c = true;
        }
        yield return new WaitForSeconds(0.5f);
        if (!Attack3path && !Attack3d)
        {
            attack3obj4 = SkellBossState.Instantiate(bossmonster.Attack3prefabs, bossmonster.Attack3point[3].transform.position, Quaternion.identity);
            Attack3d = true;
        }
        yield return new WaitForSeconds(0.5f);
        if (!Attack3path && !Attack3e)
        {
            SkellBossState.Instantiate(bossmonster.Attack3prefabs, bossmonster.Attack3point[4].transform.position, Quaternion.identity);
            Attack3e = true;
        }
        yield return new WaitForSeconds(0.5f);
        if (!Attack3path && !Attack3f)
        {
            attack3obj6 = SkellBossState.Instantiate(bossmonster.Attack3prefabs, bossmonster.Attack3point[5].transform.position, Quaternion.identity);
            Attack3f = true;
            Attack3path = true;
        }
        yield return new WaitForSeconds(0.5f);

       if (!playerchehck)
        {
            targetDir = new Vector2( bossmonster.player.transform.position.x- attack3obj1.transform.position.x, bossmonster.player.transform.position.y - attack3obj1.transform.position.y).normalized;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            attack3obj1.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            playerchehck = true;
        }
        if (playerchehck)
        {
            attack3obj1.transform.rotation = Quaternion.identity;
            attack3obj1.transform.Translate(targetDir * Time.deltaTime * 1);
  
        }


    }


}






