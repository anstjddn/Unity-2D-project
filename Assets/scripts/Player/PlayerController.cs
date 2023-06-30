using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Principal;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour, IHitable
{
    //�÷��̾� �̵�
    private Rigidbody2D playerRb;
    private Animator playeranim;
    [SerializeField] float movespeed;
    [SerializeField] float Dashpower;
    public Vector2 movedir;
    public int gold = 0;


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


    //���� ����
    [SerializeField] private GameObject Weapon;

    //�Ʒ����� ����
    private GameObject curfloor;
    // private GameObject curfloorTile;

     private void Awake()
     {
         playerRb = GetComponent<Rigidbody2D>();
         playeranim = GetComponent<Animator>();
         playerrender = GetComponent<SpriteRenderer>();
         isjumping = false;


     }


     private void Update()
     {

         Move();
         if (movedir.magnitude == 0)
         {
             playeranim.SetFloat("movespeed", 0);
             dust.SetActive(false);
         }
         else
         {
             playeranim.SetFloat("movespeed", movespeed);
             dust.SetActive(true);
         }

         if (mousepoint.x > playerRb.transform.position.x)   //�չ���
         {
             playerrender.flipX = false;
             dust.GetComponent<SpriteRenderer>().flipX = false;
            Weapon.GetComponent<SpriteRenderer>().flipX = false;

         }
         else                                               // �ڹ���
         {
             playerrender.flipX = true;
             dust.GetComponent<SpriteRenderer>().flipX = true;
            Weapon.GetComponent<SpriteRenderer>().flipX = true;
        }


         if (movedir.y == -1 && Input.GetKey(KeyCode.Space))
         {
             if (curfloor != null)
             {
                 StartCoroutine(floorRoutin());
             }

         }
     }
   // ���� ����
     private void Move()
     {
       transform.Translate(new Vector3(movedir.x, 0, 0) * movespeed * Time.deltaTime);


    }
     private void OnMove(InputValue value)
     {
         movedir.x = value.Get<Vector2>().x;
         movedir.y = value.Get<Vector2>().y;
     }
     // ��������
     private void OnJump(InputValue value)
     {

             Jump();



     }
     private void Jump()
     {

        playerRb.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);

     }

   //��ñ���  (��� ī���� ȸ���ϴ°� �����ʿ�
     private void OnDash(InputValue value)
     {
        //transform.Translate(new Vector3(mousepoint.x * Dashpower * Time.deltaTime, mousepoint.y * Dashpower * Time.deltaTime));
        transform.Translate(mousepoint.x * Dashpower * Time.deltaTime, mousepoint.y * Dashpower * Time.deltaTime, 0);
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
        if (collision.gameObject.layer ==11)
        {
            GameManager.data.basegold += 10;
            Destroy(collision.gameObject);
        }


    }
// ��������� Ǯ���°�
public void OffDamage()
      {
          gameObject.layer = 6;
          playerrender.color = new Color(1, 1, 1,1);
      }

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
        if (curfloor != null)
        {
            BoxCollider2D floorcollder = curfloor.gameObject.GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), floorcollder);
            playerRb.velocity = new Vector2(0, -9);
            yield return new WaitForSeconds(1f);
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), floorcollder, false);
        }
    /*    if (curfloorTile != null)
        {
            TilemapCollider2D floorTilecollder = curfloorTile.gameObject.GetComponent<TilemapCollider2D>();
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), floorTilecollder);
            playerRb.velocity = new Vector2(0, -9);
            yield return new WaitForSeconds(1f);
            Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), floorTilecollder, false);
        }*/
    }

    public void TakeHit(int dagame)
    {
        
         GameManager.data.curHp -= dagame;
        Debug.Log("������");
        gameObject.layer = 8;
        playerrender.color = new Color(1, 1, 1, 0.4f);
        Invoke("OffDamage", 0.5f);

    }
}
