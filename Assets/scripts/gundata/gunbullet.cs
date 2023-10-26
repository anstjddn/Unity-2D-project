using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunbullet : MonoBehaviour
{
    [SerializeField] public float bulletspeed;
    private Animator bulletanim;
    public bool hit;
    [SerializeField] public int hitdamege;
    private Transform setpos;
    private void Awake()
    {
        hit = false;
       bulletanim = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        hit = false;
    }

    private void Update()
    {
        if(!hit)
           transform.Translate(Vector2.up * Time.deltaTime * bulletspeed);
        else
        {
            transform.Translate(Vector3.zero);
        }
    }

  

   private void OnTriggerEnter2D(Collider2D collision)
    {

      
        if (collision.gameObject.layer == 9)
        {
            hit = true;
            IHitable hitable = collision.GetComponent<IHitable>();

            bulletanim.SetTrigger("hit");
            hitable?.TakeHit(hitdamege);
         //   GameManager.Pool.Release(transform.parent.gameObject);
           StartCoroutine(ReleaseRoutine(gameObject,0.5f));
          //     Destroy(gameObject, 0.4f);

        }
        if (collision.gameObject.layer == 7)
        {
            hit = true;
            bulletanim.SetTrigger("hit");
            StartCoroutine(ReleaseRoutine(gameObject, 0.5f));
            //  Destroy(gameObject, 0.4f);

        }
        if (collision.gameObject.layer == 14)
        {
            hit = true;
            bulletanim.SetTrigger("hit");
            StartCoroutine(ReleaseRoutine(gameObject, 0.5f));
            //   Destroy(gameObject, 0.4f);

        }
     
    }

    IEnumerator ReleaseRoutine(GameObject obj,float Time)
    {
        
        yield return new WaitForSeconds(Time);
        //  transform.position = setpos.position;
        //  transform.rotation = setpos.rotation;
       // hit = false;
        GameManager.Pool.Release(obj);
    }

}
