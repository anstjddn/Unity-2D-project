using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Principal;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    //플레이어 이동
    private Rigidbody2D playerRb;
    private Animator playeranim;
    [SerializeField] float movespeed;
    [SerializeField] float Dashpower;
    public Vector2 movedir;
    public int gold=0;


    //발아래 더스트 애니메이션
    [SerializeField] GameObject dust;
    // 플레이어 점프 구현
    [SerializeField] float jumppower;
    private bool isjumping;

    // 플레이어 시점 관련 구현
    Vector3 mousepoint;
    private SpriteRenderer playerrender;


    //무기 구현
    [SerializeField] private GameObject Weapon;
  


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playeranim = GetComponent<Animator>();
        playerrender = GetComponent<SpriteRenderer>();
 
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
       
        }
        else                                               // 뒤방향
        {
            playerrender.flipX = true;
            dust.GetComponent<SpriteRenderer>().flipX = true;
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
       transform.Translate(new Vector3(mousepoint.x * Dashpower * Time.deltaTime, mousepoint.y * Dashpower * Time.deltaTime));
        
    }

    private void OnPointer(InputValue value)
    {
        mousepoint = value.Get<Vector2>();
        mousepoint = Camera.main.ScreenToWorldPoint(mousepoint);
    }

    // 골드 먹었을경우 돈얻는거 구현
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gold")
        {
            GameManager.data.basegold += 10;
            Destroy(collision.gameObject);
        }
        
    }

    //플레이어 데미지 받을떄
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Debug.Log("색변함");
            gameObject.layer = 8;
            playerrender.color = new Color(1, 1, 1, 0.4f);
            Invoke("OffDamage", 0.5f);
        }
    }

    public void OffDamage()
    {
        gameObject.layer = 0;
        playerrender.color = new Color(1, 1, 1,1);
    }
   

}
