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
    [SerializeField] GameObject dust;
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
       
        }
        else                                               // �ڹ���
        {
            playerrender.flipX = true;
            dust.GetComponent<SpriteRenderer>().flipX = true;
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
       transform.Translate(new Vector3(mousepoint.x * Dashpower * Time.deltaTime, mousepoint.y * Dashpower * Time.deltaTime));
        
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

    //�÷��̾� ������ ������
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Debug.Log("������");
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
