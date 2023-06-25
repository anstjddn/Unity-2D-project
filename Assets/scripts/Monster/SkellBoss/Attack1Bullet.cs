using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1Bullet : MonoBehaviour
{
    [SerializeField] public float bulletspeed;
    private Animator bulletanim;
    private bool hit;
    private void Awake()
    {
        hit = false;
        bulletanim = GetComponent<Animator>();
        
       
    }
    void Update()
    {
        if (!hit)
        {
            transform.Translate(Vector3.right * Time.deltaTime * bulletspeed);
        }
        else
        {
            transform.Translate(Vector3.zero);
        }
      
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hit = true;
            bulletanim.SetTrigger("hit");
            GameManager.data.curHp -= 10;
            Destroy(gameObject, 0.4f);
            
          
        }
    }

}
