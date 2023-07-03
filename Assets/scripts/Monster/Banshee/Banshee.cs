using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Banshee : MonoBehaviour, IHitable
{
    [SerializeField] public int hp;
    [SerializeField] GameObject textprefabs;
    [SerializeField] GameObject coinprefabs;
    [SerializeField] private int coinmoney;
    [SerializeField] GameObject dieeffect;
    private void Awake()
    {
        coinmoney = Random.Range(5, 11);
    }
    private void Update()
    {

        if (hp > 0)
        {
          
        }
        else
        {
            Destroy(gameObject);
            dieeffect = Instantiate(dieeffect, transform.position, Quaternion.identity);
            Destroy(dieeffect, 3f);
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
