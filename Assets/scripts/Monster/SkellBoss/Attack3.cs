using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class Attack3 : MonoBehaviour
{
    [SerializeField] public int damage;
    [SerializeField] GameObject hiteffect;
    bool isLooking;
    Transform player;
    public bool isAttack;
    [SerializeField] float Attack3speed;
    public bool isground;
    public bool hitable;
    Vector2 targetDir;

    private void Update()
    {
        if (isLooking)
        {
            Aim();
        }
        if (isAttack && !isground)
        {
            Attack();
        }
        if (isground)
          {
              transform.Translate(Vector3.zero);
             if (!hitable)
                 {
                     Instantiate(hiteffect, transform.position, Quaternion.identity);
                     hitable = true;
                 }
           }
    }

    public void SetTarget(Transform player)
    {
        this.player = player;
    }

    public void Aim()
    {
        isLooking = true;

        targetDir = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y).normalized;
        transform.up = targetDir;

    }

    public void Attack()
    {
        isLooking = false;
        isAttack = true;
        transform.position -= transform.up.normalized * Attack3speed * Time.deltaTime;
        //transform.Translate(transform.up * Time.deltaTime * Attack3speed);
        GameObject idleffect = transform.GetChild(0).gameObject;                //날아갈때 주변 임펙트끄기
        idleffect.SetActive(false);
    }
    public void Remove()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            IHitable hitable = collision.GetComponent<IHitable>();
            hitable?.TakeHit(damage);
        }
       if (collision.gameObject.layer == 7)
           {
               Invoke("GroundCheck", 0.2f);
           }
       }
       private void GroundCheck()
       {
           isground = true;

       }
    }



