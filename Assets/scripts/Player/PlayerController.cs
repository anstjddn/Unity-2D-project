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
    //�÷��̾� �̵�
    private Rigidbody2D playerRb;
    private Animator playeranim;
    [SerializeField] float movespeed;
    [SerializeField] float Dashpower;
    public Vector2 movedir;
    public int gold=0;


    //�߾Ʒ� ����Ʈ �ִϸ��̼�
    [SerializeField] GameObject leftdust;
    // �÷��̾� ���� ����
    [SerializeField] float jumppower;
    private bool isjumping;

    // �÷��̾� ���� ���� ����
    Vector3 mousepoint;
    private SpriteRenderer playerrender;


    //���� ����
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
        /*   if (value.isPressed)
           {

               playerRb.velocity = new Vector2(playerRb.velocity.x, jumppower);
               isjumping = true;
               playeranim.SetTrigger("Jump");
           }

           if (isjumping && playerRb.velocity.y > 0)
           {
               playerRb.velocity = new Vector2(playerRb.velocity.x, 0);
               isjumping = false;
           }*/
        Jump();
         
    }
    private void Jump()
    {
        
       playerRb.velocity = new Vector2(playerRb.velocity.x, jumppower);
         //   playerRb.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
          //  playeranim.SetTrigger("Jump");
    }
  //��ñ���  (��� ī���� ȸ���ϴ°� �����ʿ�
    private void OnDash(InputValue value)
    {
        playerRb.velocity = mousepoint.normalized*Dashpower ;
    }

    private void OnPointer(InputValue value)
    {
        mousepoint = value.Get<Vector2>();
        mousepoint = Camera.main.ScreenToWorldPoint(mousepoint);
    }

    // ��� �Ծ������ ����°� ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Gold")
        {
            GameManager.data.basegold += 10;
            Destroy(collision.gameObject);
        }
    }
    
}
