using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banshee : MonoBehaviour, IHitable
{
    [SerializeField] public int hp;
    [SerializeField] GameObject textprefabs;
    [SerializeField] GameObject coinprefabs;
    [SerializeField] private int coinmoney;
    [SerializeField] GameObject dieeffect;
    [SerializeField] Transform playerpos;

    private SpriteRenderer renderer; 
    private void Awake()
    {
        renderer.GetComponent<SpriteRenderer>();
        coinmoney = Random.Range(5, 11);                                        //이게 에어 몬스터 공용
    }
    private void Update()
    {

        if (hp <= 0)
      
            Destroy(gameObject);
            dieeffect = Instantiate(dieeffect, transform.position, Quaternion.identity);
            Destroy(dieeffect, 3f);
            StartCoroutine(CoinRoutin());
        if((transform.position.x - playerpos.position.x)> 0)                //플레이어 왼쪽
        {
            renderer.flipX = true;
        }
        else
        {
            renderer.flipX = false;
        }


    }

    public void TakeHit(int dagame)
    {
        Instantiate(textprefabs, transform.position, Quaternion.identity);
        hp -= dagame;
    }

    IEnumerator CoinRoutin()
    {
        while (coinmoney > 0)
        {
            Instantiate(coinprefabs, transform.position, Quaternion.identity);
            coinmoney--;
        }
        yield return null;
    }




}
