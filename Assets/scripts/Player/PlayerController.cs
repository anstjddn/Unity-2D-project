using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator playeranim;


    private Vector2 movedir;
    [SerializeField] float movespeed;
    [SerializeField] float Dashpower;

    [SerializeField] float jumppower;
    [SerializeField] Transform WeaponHolder;

    [SerializeField] GameObject ob;
    Vector2 mousepoint;

    private SpriteRenderer playerrender;
    
  



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
        }
        else playeranim.SetFloat("movespeed", movespeed);
        if (mousepoint.x > playerRb.transform.position.x)
        {
            playerrender.flipX = false;
   
        }
        else
        {
            playerrender.flipX = true;
         
        }

    }
    private void LateUpdate()
    {
        ob.transform.position = mousepoint;
    }
    private void Move()
    {
        
        transform.Translate(new Vector3(movedir.x, 0, 0) * movespeed * Time.deltaTime);
        
    }
    private void OnMove(InputValue value)
    {
        movedir.x = value.Get<Vector2>().x;


    }
   
    private void OnJump(InputValue value)
    {
        Jump();

    }
    private void Jump()
    {
        playerRb.AddForce(Vector2.up * jumppower, ForceMode2D.Impulse);
        playeranim.SetTrigger("Jump");
    }
  
    private void OnDash(InputValue value)
    {
        playerRb.AddForce(mousepoint* Dashpower, ForceMode2D.Impulse);
    }
    private void OnPointer(InputValue value)
    {
        mousepoint = value.Get<Vector2>();
        Camera.main.ScreenToWorldPoint(mousepoint);
     
    }
    
    private void Dust()
    {

    }
  
}
