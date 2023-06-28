using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWhiteSkel : MonoBehaviour, IHitable
{
    [SerializeField] public int hp;
    [SerializeField] GameObject textprefabs;
    [SerializeField] GameObject coinprefabs;
    [SerializeField] private int coinmoney;
    private void Awake()
    {
        coinmoney = Random.Range(5, 11);
    }
    private void Update()
    {

       if (hp > 0)
        {
           // Debug.Log(hp);
        }
        else
        {
            Destroy(gameObject);

            StartCoroutine(CoinRoutin());
            
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
