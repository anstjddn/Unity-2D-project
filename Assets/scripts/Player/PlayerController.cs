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
    //플레이어 이동
    private Rigidbody2D playerRb;
    private Animator playeranim;
    [SerializeField] float movespeed;
    [SerializeField] float Dashpower;
    public Vector2 movedir;
    public int gold = 0;


    //발아래 더스트 애니메이션
    [SerializeField] GameObject dust;
    // 플레이어 점프 구현
    [SerializeField] float jumppower;
    private bool isjumping;
    //발아래 체크후 1단점프만
    [SerializeField] Transform footarea;
    [SerializeField] float footrange;
    private bool isgroundcheck;
    [SerializeField] LayerMask whatground;

    // 플레이어 시점 관련 구현
    Vector3 mousepoint;
    private SpriteRenderer playerrender;


    //무기 구현
    [SerializeField] private GameObject Weapon;

    //아래점프 구현
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

         if (mousepoint.x > playerRb.transform.position.x)   //앞방향
         {
             playerrender.flipX = false;
             dust.GetComponent<SpriteRenderer>().flipX = false;
            Weapon.GetComponent<SpriteRenderer>().flipX = false;

         }
         else                                               // 뒤방향
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
   // 무브 구현
     private void Move()
     {
       transform.Translate(new Vector3(movedir.x, 0, 0) * movespeed * Time.deltaTime);


    }
     private void OnMove(InputValue value)
     {
         movedir.x = value.Get<Vector2>().x;
         movedir.y = value.Get<Vector2>().y;
     }
     // 점프구현
     private void OnJump(InputValue value)
     {

             Jump();



     }
     private void Jump()
     {

        playerRb.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);

     }

   //대시구현  (대시 카운터 회복하는거 구현필요
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



   //뚫고 내려가기, 돈먹는거 구현
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
// 무적됬따가 풀리는거
public void OffDamage()
      {
          gameObject.layer = 6;
          playerrender.color = new Color(1, 1, 1,1);
      }

      //floor로 발꺼지는거
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
        Debug.Log("색변함");
        gameObject.layer = 8;
        playerrender.color = new Color(1, 1, 1, 0.4f);
        Invoke("OffDamage", 0.5f);

    }
}
