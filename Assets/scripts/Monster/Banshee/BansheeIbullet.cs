using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BansheeIbullet : MonoBehaviour
{
    [SerializeField] public float bulletspeed;
    private Animator bulletanim;
    private bool hit;
    [SerializeField] public int hitdamege;
    private void Awake()
    {
        hit = false;
        bulletanim = GetComponent<Animator>();
        StartCoroutine(Destory(gameObject,5f));

    }
    private void OnEnable()
    {
        hit = false;
        StartCoroutine(Destory(gameObject, 5f));
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

            IHitable hitable = collision.gameObject.GetComponentInChildren<IHitable>();
            hit = true;

            bulletanim.SetTrigger("hit");
            hitable?.TakeHit(hitdamege);
            StartCoroutine(Destory(gameObject, 0.5f));
         //   Destroy(gameObject, 0.4f);

        }
    }

    IEnumerator Destory(GameObject obj,float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Pool.Release(obj);
        //Destroy(gameObject);
    }
}
