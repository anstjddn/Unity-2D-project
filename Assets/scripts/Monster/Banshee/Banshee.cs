using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Purchasing;
using UnityEngine;
using UnityEngine.UI;

public class Banshee : MonoBehaviour, IHitable
{
    [SerializeField] public int maxhp;
    [SerializeField] GameObject textprefabs;
    [SerializeField] GameObject coinprefabs;
    [SerializeField] private int coinmoney;
    [SerializeField] GameObject dieeffect;
    [SerializeField] public int curhp;
    [SerializeField] Slider hpbar;
    [SerializeField] Canvas hpbackground;

    private SpriteRenderer hit;
    private void Awake()
    {
        coinmoney = Random.Range(5, 11);
        hit = GetComponent<SpriteRenderer>();
        curhp = maxhp;
        hpbar.maxValue = maxhp;
        hpbar.value = curhp;
        hpbackground.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        coinmoney = Random.Range(5, 11);
        hit = GetComponent<SpriteRenderer>();
        curhp = maxhp;
        hpbar.maxValue = maxhp;
        hpbar.value = curhp;
        hpbackground.gameObject.SetActive(false);
    }

    public void TakeHit(int dagame)
    {
      
        SoundManager.Instance.PlaySFX("MonsterHit");
        hpbackground.gameObject.SetActive(true);
        Instantiate(textprefabs, transform.position, Quaternion.identity);
        curhp -= dagame;
        hpbar.value = curhp;
        hit.color = new Color(255, 0, 0, 255);
       StartCoroutine(damageRoutin());
        //  Invoke("prihit", 0.1f);
        if (curhp <= 0)
        {
            SoundManager.Instance.PlaySFX("MonsterDie");
            StartCoroutine(CoinRoutin());
            GameManager.Pool.Release(gameObject);
            StartCoroutine(DieRoutine(0.5f));
        }
    }

    IEnumerator CoinRoutin()
    {
        while (coinmoney > 0)
        {
           GameObject coin= GameManager.Pool.Get(coinprefabs, transform.position, Quaternion.identity);
            coinmoney--;
        }
        yield return null;
    }

    IEnumerator damageRoutin()
    {
        hit.color = new Color(255, 255, 255, 255);
        yield return new WaitForSeconds(0.3f);
    }
    IEnumerator DieRoutine(float time)
    {
        GameObject monsterdie = GameManager.Pool.Get(dieeffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(time);
        GameManager.Pool.Release(monsterdie);
    }

} 

   
   