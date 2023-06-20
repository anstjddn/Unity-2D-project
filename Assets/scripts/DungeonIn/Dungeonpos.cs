using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Dungeonpos : MonoBehaviour
{
    private Animator Dungeoinanim;
    [SerializeField] Transform playerpos;
    public UnityEvent Onplayed;
    [SerializeField] float pos;


    private void Awake()
    {
        Dungeoinanim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
 
            playerpos.position = new Vector2(collision.transform.position.x, collision.transform.position.y + pos);
            Onplayed?.Invoke();
            Debug.Log("플레이어 던전진입");

            //  collision.GetComponent<PlayerInput>();

        }
    }
   
}
