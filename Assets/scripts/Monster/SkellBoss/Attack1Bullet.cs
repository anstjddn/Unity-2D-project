using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1Bullet : MonoBehaviour
{
    [SerializeField] public float bulletspeed;
    private Animator bulletanim;
    private bool hit;
    [SerializeField] public int hitdamege;
    private void Awake()
    {
        hit = false;
        bulletanim = GetComponent<Animator>();
        StartCoroutine(ReleaseRoutine(5f));
    }
    private void OnEnable()
    { 
            hit = false;
        StartCoroutine(ReleaseRoutine(5f));
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
        if (collision.gameObject.layer == 6)
        {

            IHitable hitable = collision.GetComponent<IHitable>();
            hit = true;
           
            bulletanim.SetTrigger("hit");
            hitable?.TakeHit(hitdamege);
            StartCoroutine(ReleaseRoutine(0.5f));
     
            


        }
    }

    IEnumerator ReleaseRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Pool.Release(gameObject);
    }

}
