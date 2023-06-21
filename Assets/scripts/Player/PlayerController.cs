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
    public Rigidbody2D playerRb;
    public Animator playeranim;
    [SerializeField] float movespeed;
    [SerializeField] float Dashpower;
    public Vector2 movedir;
    public int gold=0;


    //발아래 더스트 애니메이션
    [SerializeField] GameObject leftdust;
    // 플레이어 점프 구현
    [SerializeField] float jumppower;

    // 플레이어 시점 관련 구현
    Vector3 mousepoint;
    private SpriteRenderer playerrender;


    //무기 구현
    private GameObject Weapon;



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
            leftdust.SetActive(false);
        }
        else
        {
            playeranim.SetFloat("movespeed", movespeed);
            leftdust.SetActive(true);
        }

        if (mousepoint.x > playerRb.transform.position.x)
        {
            playerrender.flipX = false; 
        }
        else
        {
            playerrender.flipX = true;
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
            playeranim.SetTrigger("Jump");
    }
  //대시구현  (대시 카운터 회복하는거 구현필요
    private void OnDash(InputValue value)
    {
      playerRb.AddForce(mousepoint* Dashpower, ForceMode2D.Impulse);
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
    
}
