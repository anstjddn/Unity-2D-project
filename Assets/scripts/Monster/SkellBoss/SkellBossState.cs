using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.XR;

public class SkellBossState : MonoBehaviour
{
    public enum State { Idle, Attack1, Attack2, Attack3, size }
    public Transform player;
    private BaseState[] states;
    private State curstate;
    [SerializeField] public int Handspeed;
    public Rigidbody2D monsterRb;
    public Animator monsteranim;
    public Collider2D monsterCollider;
    [SerializeField] public GameObject[] handobj;
    [SerializeField] public GameObject Attack1;
    [SerializeField] public Transform[] Attackpoints;
    [SerializeField] public float rotatespeed;



   // public int Randpatton = Random.Range((int)State.Attack1, (int)State.Attack3);

    [SerializeField] public Attack3 Attack3prefabs;
    

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

     public void ChangeState()
      {

           int rand = Random.Range(1, 4);
           states[(int)curstate].Exit();
           curstate = (State)rand;
           states[(int)curstate].Enter();


      /*  states[(int)curstate].Exit();
        curstate = (State)2;
        states[(int)curstate].Enter();*/

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
     
        bossmonster.ChangeState();
        Debug.Log("Idle Enter");
    }
    public override void Exit()
    {
        Debug.Log("Idle Exit");

    }

    public override void Update()
    {
      //  bossmonster.ChangeState(SkellBossState.State.Attack1);


    }
}
public class BossAttack1State : BaseState             //입에서 회전
{
    public SkellBossState bossmonster;
    public bool isattack;
    public float curTime;
    public BossAttack1State(SkellBossState bossmonster)
    {
        this.bossmonster = bossmonster;
    }

    public override void Enter()
    {
        curTime = 0;
        bossmonster.monsteranim.SetBool("Attack1", true);
        Debug.Log("Attack1 Enter");
        isattack = false;
    }

    public override void Exit()
    {
        Debug.Log("Attack1 Exit");
  
    }

    public override void Update()
    {

        curTime += Time.deltaTime;
        if (curTime > 5f)
        {
            bossmonster.monsteranim.SetBool("Attack1", false);
            bossmonster.StopAllCoroutines();
            bossmonster.ChangeState();

        }
        if (!isattack)
        {
            bossmonster.StartCoroutine(AttackRoutin(0.4f));
            
        }
        Debug.Log("Attack1 Update");
        foreach (Transform t in bossmonster.Attackpoints)                                       //회전
        {
            t.Rotate(-Vector3.back * bossmonster.rotatespeed * Time.deltaTime);
           
        }
   

    }
    IEnumerator AttackRoutin(float dalay)
    {
        isattack = true;
        if (isattack)
        {
            foreach (Transform t in bossmonster.Attackpoints)
            {
                SoundManager.Instance.PlaySFX("BossAttack1");
              GameObject Skllobssbullet = GameManager.Pool.Get(bossmonster.Attack1, t.position, t.rotation);        //동시에 생성
            }
            
        }
        yield return new WaitForSeconds(dalay);
        isattack = false;





    }
    IEnumerator ReleaseRoutine(GameObject obj,float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Pool.Release(obj);
    }
    
}

public class BossAttack2State : BaseState               //손따라가서 레이저
{
    public SkellBossState bossmonster;
    private bool isAttack2left;
    private bool isAttack2right;
    private bool isAttack2end;
    private bool isAttack2last;
    private GameObject leftobj;
    private GameObject rightobj;
    private GameObject leftlayer;
    private GameObject rightlayer;
    private bool isattack;

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
        isAttack2last = false;
        isattack = false;
    }

    public override void Exit()
    {
        Debug.Log("Attack2 Exit");
        leftlayer.SetActive(false);
        rightlayer.SetActive(false);

        isattack = false;
        isAttack2left = false;
        isAttack2right = false;
        isAttack2end = false;
        isAttack2last = false;
    }

    public override void Update()
    {

      
        if (!isattack)
        {
            bossmonster.StartCoroutine(Attack2Routin());
        }
        

         if (isAttack2last)
         {
             bossmonster.ChangeState();
            isattack = true;
         }


    }
    IEnumerator Attack2Routin()
    {
          Debug.Log("들어감");
         leftobj = bossmonster.handobj[0];
         rightobj = bossmonster.handobj[1];
         leftlayer = leftobj.transform.GetChild(0).gameObject;
         rightlayer = rightobj.transform.GetChild(0).gameObject;

        yield return new WaitForSeconds(2f);
        if (Mathf.Abs(bossmonster.player.position.y - leftobj.transform.position.y) > 0.1f && !isAttack2left)
        {
            Vector2 playerdirleft = (bossmonster.player.position - leftobj.transform.position);
            playerdirleft = new Vector2(0, playerdirleft.y).normalized;
            leftobj.transform.Translate(playerdirleft * bossmonster.Handspeed * Time.deltaTime);

        }

        if (!isAttack2left &&Mathf.Abs(leftobj.transform.position.y - bossmonster.player.position.y) < 0.1f)
        {

            leftobj.transform.Translate(Vector3.zero);
            isAttack2left = true;
            leftobj.GetComponent<Animator>().SetBool("Attack", true);
            SoundManager.Instance.PlaySFX("BossAttack2");
           // isAttack2left = true;
            yield return new WaitForSeconds(0.8f);
            leftlayer.SetActive(true);
            leftobj.GetComponent<Animator>().SetBool("Attack", false);
            yield return new WaitForSeconds(1f);
            leftlayer.SetActive(false);
        }
 
            yield return new WaitForSeconds(1.5f);   //왼손쓰고 1초후 오른손

            if (!isAttack2right&& Mathf.Abs(rightobj.transform.position.y - bossmonster.player.position.y) > 0.1f)
            {

                Vector2 playerdirRight = (bossmonster.player.position - rightobj.transform.position);
                playerdirRight = new Vector2(0, playerdirRight.y).normalized;
                rightobj.transform.Translate(playerdirRight * bossmonster.Handspeed * Time.deltaTime);

            }


            if (!isAttack2right && Mathf.Abs(rightobj.transform.position.y - bossmonster.player.position.y) < 0.1f)
            {
             
                rightobj.transform.Translate(Vector3.zero);
                isAttack2right = true;
                rightobj.GetComponent<Animator>().SetBool("righthand", true);
            SoundManager.Instance.PlaySFX("BossAttack2");
            //   isAttack2right = true;
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
                leftobj.transform.Translate(playerdirleft * bossmonster.Handspeed * Time.deltaTime);

            }

            if (Mathf.Abs(leftobj.transform.position.y - bossmonster.player.position.y) < 0.1f && !isAttack2last)
            {
            
                leftobj.transform.Translate(Vector3.zero);
            isAttack2last = true;
            leftobj.GetComponent<Animator>().SetBool("Attack", true);
            SoundManager.Instance.PlaySFX("BossAttack2");
            //   isAttack2last = true;
            yield return new WaitForSeconds(0.8f);
                leftlayer.SetActive(true);
                leftobj.GetComponent<Animator>().SetBool("Attack", false);
             //   isAttack2last = true; 
                yield return new WaitForSeconds(1f);
               leftlayer.SetActive(false);

            }
            yield return new WaitForSeconds(7f);

        }
     
    }
    public class BossAttack3State : BaseState                           //칼 꼿히는거
    {
        public SkellBossState bossmonster;
        List<Attack3> attack3List = new List<Attack3>();

    public BossAttack3State(SkellBossState bossmonster)
    {
            this.bossmonster = bossmonster;
         
    }

    public override void Enter()
    {
        Debug.Log("Attack3 Enter");
        bossmonster.StartCoroutine(Attack3routin());
    }
        public override void Exit()
        {
            Debug.Log("Attack3 Exit");
        }
    public override void Update()
    {
        Debug.Log("Attack3 Update");
        
    }

    IEnumerator Attack3routin()
    {
       // List<Attack3> attack3List = new List<Attack3>();
        int swordCount = 6;
        for (int i = 0; i < swordCount; i++)
        {
            float posX = bossmonster.transform.position.x - 5f + i * 2f;
            float posY = bossmonster.transform.position.y + 5;
            Attack3 attack3 = SkellBossState.Instantiate(bossmonster.Attack3prefabs, new Vector2(posX, posY), Quaternion.identity);
            SoundManager.Instance.PlaySFX("BossAttack3");
            attack3.SetTarget(bossmonster.player.transform);
            attack3.Aim();
            attack3List.Add(attack3);

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < swordCount; i++)
        {
            attack3List[i].Attack();

            yield return new WaitForSeconds(0.5f);
        }
        yield return new WaitForSeconds(2f);
      /*  if (attack3List[5].hitable)
        {
            for (int i = 0; i < 6; i++)
            {
                attack3List[i].RemoveSwordObj();
            }
         //   bossmonster.ChangeState(SkellBossState.State.Attack1);
           // bossmonster.StopAllCoroutines();
        }*/
        for (int i = 0; i < 6; i++)
        {
            attack3List[i].RemoveSwordObj();
        }
        attack3List.Clear();
        yield return new WaitForSeconds(0.5f);
        bossmonster.ChangeState();
    }

    }






