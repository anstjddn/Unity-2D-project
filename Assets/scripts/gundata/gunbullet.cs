using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunbullet : MonoBehaviour
{
    [SerializeField] public float bulletspeed;
    private Animator bulletanim;
    private bool hit;
    [SerializeField] public int hitdamege;
    private void Awake()
    {
        hit = false;
       bulletanim = GetComponent<Animator>();

    }
    void Update()
    {
        if (!hit)
        {
            transform.Translate(Vector3.up * Time.deltaTime * bulletspeed);
        }
        else
        {
            transform.Translate(Vector3.zero);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("�浹��");
        if (collision.gameObject.layer == 9)
        {

            IHitable hitable = collision.GetComponent<IHitable>();
            hit = true;

            bulletanim.SetTrigger("hit");
            hitable?.TakeHit(hitdamege);
            Destroy(gameObject, 0.4f);

        }
        if (collision.gameObject.layer == 7)
        {

       
            hit = true;

            bulletanim.SetTrigger("hit");
  
            Destroy(gameObject, 0.4f);

        }
        if (collision.gameObject.layer == 14)
        {          
            hit = true;
            bulletanim.SetTrigger("hit");
            Destroy(gameObject, 0.4f);

        }
     
    }
  
}
