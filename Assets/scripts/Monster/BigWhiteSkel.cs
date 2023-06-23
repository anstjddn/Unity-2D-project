using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWhiteSkel : MonoBehaviour, IHitable
{
    [SerializeField] private int hp;
    [SerializeField] private int defance;
    [SerializeField] private int damage;
    [SerializeField]private Collider2D Attackpoint;
    private void Update()
    {
        Attackpoint.enabled = false;
    }
    public void Hit()
    {
        Attackpoint.enabled = true;
  

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

          if (collision.gameObject.CompareTag("Player"))
          {
              Debug.Log("데미지받음");
              GameManager.data.curHp -= damage;
          } 

        
    }

    public void TakeHit(int damage)
    {
        Destroy(gameObject);
    }
}
