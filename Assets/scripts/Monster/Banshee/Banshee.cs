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

    private SpriteRenderer hit;
    private void Awake()
    {
        coinmoney = Random.Range(5, 11);
        hit = GetComponent<SpriteRenderer>();
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
        hit.color = new Color(255, 0, 0, 255);
        Invoke("prihit", 0.1f);
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
    private void prihit()
    {
        hit.color = new Color(255, 255, 255, 255);
    }

} 

   
   