using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Transactions;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    //�÷��̾� �̵�
    private Rigidbody2D playerRb;
    private Animator playeranim;
    [SerializeField] float movespeed;
    [SerializeField] float Dashpower;
    public Vector2 movedir;


    //�߾Ʒ� ����Ʈ �ִϸ��̼�
    [SerializeField] GameObject dust;
    // �÷��̾� ���� ����
    [SerializeField] float jumppower;
    private bool isjumping;
    //�߾Ʒ� üũ�� 1��������
    [SerializeField] Transform footarea;
    [SerializeField] float footrange;
    private bool isgroundcheck;
    [SerializeField] LayerMask whatground;


    // �÷��̾� ���� ���� ����
    Vector3 mousepoint;
    private SpriteRenderer playerrender;

    //�Ʒ����� ����
    private GameObject curfloor;
    // private GameObject curfloorTile;


    //���� ������
    [SerializeField] Transform weaponhold;
   
    
    //�뽬 ����
    Vector2 dir;
    //�뽬 �ϴ��߰� �ð� ����
    public float dashTime= 0.3f;
    public bool isdashing;
    public int dashcount;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playeranim = GetComponent<Animator>();
        playerrender = GetComponent<SpriteRenderer>();
        isjumping = false;
        weaponhold = transform.GetChild(0).transform;
        dashcount = GameManager.data.dashcount;
    }


    private void Update()   
    {
   
        Vector2 scale = weaponhold.transform.localScale;
        dir = (mousepoint - transform.position).normalized;
        Move();

        if (movedir.magnitude == 0|| isjumping)
         {
             playeranim.SetFloat("movespeed", 0);
             dust.SetActive(false);
         }
         else if(movedir.magnitude != 0 || !isjumping)
         {
             playeranim.SetFloat("movespeed", movespeed);
             dust.SetActive(true);
         }
        else if (movedir.magnitude != 0 || isjumping)
        {
            dust.SetActive(false);
        }

            if (mousepoint.x > playerRb.transform.position.x)   //�չ���
         {
             playerrender.flipX = false;
             dust.GetComponent<SpriteRenderer>().flipX = false;
            scale.y = 1;
           
            weaponhold.localPosition= new Vector3(0.08f, -0.03f, 0);

        }
         else                                               // �ڹ���
         {
             playerrender.flipX = true;
             dust.GetComponent<SpriteRenderer>().flipX = true;
            scale.y = -1;
         
            weaponhold.localPosition = new Vector3(-0.08f, -0.03f, 0);
        }
        weaponhold.transform.localScale = scale;

         if (movedir.y == -1 && Input.GetKey(KeyCode.Space))
         {
             if (curfloor != null)
             {
                 StartCoroutine(floorRoutin());
             }

         }

        isgroundcheck = Physics2D.OverlapCircle(footarea.position, footrange, whatground);
        if (isgroundcheck) //�浹��
          {
              isjumping = false;
              playeranim.SetBool("Jump", false);
          }
       else
        {
            dust.SetActive(false);
            playeranim.SetBool("Jump", true);
        }
        /*  if (isjumping)
          {
              dust.SetActive(false);
          }*/
       // Debug.Log(mousepoint);
    }
   // ���� ����
     private void Move()
     {
       // SoundManager.Instance.PlaySFX("PlayerMove");
        transform.Translate(new Vector3(movedir.x, 0, 0) * movespeed * Time.deltaTime);

    }
     private void OnMove(InputValue value)
     {
        SoundManager.Instance.PlaySFX("PlayerMove");
        movedir.x = value.Get<Vector2>().x;
         movedir.y = value.Get<Vector2>().y;
     }
     // ��������
     private void OnJump(InputValue value)
     {
        if (isgroundcheck)                   
        {
            Jump(); 
        }
       
    }
     private void Jump()
     {
        SoundManager.Instance.PlaySFX("PlayerJump");
        playerRb.velocity = Vector2.up * jumppower;

     }

   //��ñ���  (��� ī���� ȸ���ϴ°� �����ʿ�
     private void OnDash(InputValue value)
     {
        if (dashcount > 0)
        {
            SoundManager.Instance.PlaySFX("playerdash");
            StartCoroutine(dashroutin());
        }

       }
 

     private void OnPointer(InputValue value)
     {
         mousepoint = value.Get<Vector2>();
       mousepoint = Camera.main.ScreenToWorldPoint(mousepoint);
      
     }



   //�հ� ��������, ���Դ°� ����
     public void OnCollisionEnter2D(Collision2D collision)
     {
       
         if (collision.gameObject.CompareTag("Floor"))
         {
             curfloor = collision.gameObject;
         }
        /*  if (collision.gameObject.CompareTag("TileFloor"))
          {
              curfloorTile = collision.gameObject;
          }*/
    /*    if (collision.gameObject.layer ==11)
        {
            GameManager.data.BaseGold += 10;
            Destroy(collision.gameObject);
        }*/
      /*  if(isdashing&& collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<IHitable>().TakeHit(GameManager.data.playerDamege);
        }*/

    }
// ��������� Ǯ���°�



/*      public void OffDamage()
      {
          gameObject.layer = 6;
          playerrender.color = new Color(1, 1, 1,1);
      }*/

      //floor�� �߲����°�    
      private void OnCollisionExit2D(Collision2D collision)
      {
          if (collision.gameObject.CompareTag("Floor"))
          {
              curfloor = null;

          }
          /*if (collision.gameObject.CompareTag("TileFloor"))
          {
              curfloorTile = null;
          }*/

    }
    IEnumerator floorRoutin()
    {
      /*  if (curfloor != null)
        {
            BoxCollider2D floorcollder = curfloor.gameObject.GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), floorcollder);
            playerRb.velocity = new Vector2(0, -9);
            yield return new WaitForSeconds(1f);
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), floorcollder, false);
        }*/
        if(curfloor != null)
        {
            BoxCollider2D floorcollder = curfloor.gameObject.GetComponent<BoxCollider2D>();
            floorcollder.enabled = false;
            playerRb.velocity = new Vector2(0, -9);
            yield return new WaitForSeconds(0.5f);
            floorcollder.enabled = true;
        }
   
    }

  /*  public void TakeHit(int dagame)
    {
         GameManager.data.curHp -= dagame;
        if (GameManager.data.curHp <= 0)
        {
            Ondeaded?.Invoke();
          //  GameManager.data.Set();
        }


        Debug.Log("������");
        gameObject.layer = 8;
        playerrender.color = new Color(1, 1, 1, 0.4f);
        Invoke("OffDamage", 0.5f);

    }*/

    IEnumerator dashroutin()
    {
        dashTime -= Time.deltaTime;
        if (dashTime > 0)
        {
           
            playerRb.velocity = dir.normalized * Dashpower;
            isdashing = true;
            dashcount--;
            StartCoroutine(dashheal());
            yield return new WaitForSeconds(0.5f);
           transform.gameObject.layer = 6;
           isdashing = false;
        
        }
        else
        {
            playerRb.velocity = Vector2.zero;
          //  playerRb.velocity = new Vector2(0,Physics2D.gravity.y);
        }
 
    }
    IEnumerator dashheal()
    {
        yield return new WaitForSeconds(3f);
        if (dashcount < 2)
        {
            dashcount++;
        }
       
    }
}
