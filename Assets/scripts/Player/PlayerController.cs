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
    public Rigidbody2D playerRb;
    public Animator playeranim;


    public Vector2 movedir;
    [SerializeField] float movespeed;
    [SerializeField] float Dashpower;
    [SerializeField] GameObject dust;

    [SerializeField] float jumppower;

 
    [SerializeField] Transform WeaponHolder;
    [SerializeField] UnityEvent WeaponPositionChanged;

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
            dust.SetActive(false);
        }
        else
        {
            playeranim.SetFloat("movespeed", movespeed);
            dust.SetActive(true);
        }

        if (mousepoint.x > playerRb.transform.position.x)
        {
            playerrender.flipX = false;
        }
        else
        {
            playerrender.flipX = true;

        }
      /*  if(mousepoint.x < playerRb.transform.position.x&& movedir.x < 0)
        {
            playerrender.flipX = true;
            dust.GetComponent<SpriteRenderer>().flipX = true;
            
        }*/
       

    }
    private void LateUpdate()
    {
        ob.transform.position = Camera.main.ScreenToWorldPoint(mousepoint);
        
    }
    private void Move()
    {
       
      transform.Translate(new Vector3(movedir.x, 0, 0) * movespeed * Time.deltaTime);
        

    }
    private void OnMove(InputValue value)
    {
        movedir.x = value.Get<Vector2>().x;
        movedir.y = value.Get<Vector2>().y;
       
        

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
      //  Camera.main.ScreenToWorldPoint(mousepoint);
     
    }
    
    private void Dust()
    {

    }
  
  
}
