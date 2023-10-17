using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ITemBox : MonoBehaviour, Iinteractable
{
    private Animator anim;
    [SerializeField] GameObject interactkey; //FŰ
    [SerializeField] GameObject Coinobj;
    [SerializeField] GameObject Bullionobj;
    private int coinmoney;
    private int bullionmoney;
    private bool isopening;

    private void Awake()
    {
        interactkey.SetActive(false);
        anim = GetComponent<Animator>();
        coinmoney = Random.Range(30, 50);
        bullionmoney = Random.Range(10, 12);

    }
    private void OnTriggerEnter2D(Collider2D collision)             //��ȣ�ۿ� ��Ű
    {
        if (collision.gameObject.layer ==6&&!isopening)
        {
            interactkey.SetActive(true);
        }


    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && !isopening)
        {
            interactkey.SetActive(false);
        }

    }


    //�����µ���������
    IEnumerator CoinRoutin()
    {
        while (coinmoney > 0)
        {
            GameObject coin = GameManager.Pool.Get(Coinobj, transform.position, Quaternion.identity);
        //    Instantiate(Coinobj, transform.position, Quaternion.identity);
            
            coinmoney--;
        }
        yield return null;
    }
    IEnumerator bullionRoutin()
    {
        while (bullionmoney > 0)
        {
            GameObject Bullio = GameManager.Pool.Get(Bullionobj, transform.position, Quaternion.identity);
           // Instantiate(Bullionobj, transform.position, Quaternion.identity);

            bullionmoney--;
        }
        yield return null;
    }

    public void interact()
    {
        isopening = true;
        anim.SetBool("Hit", true);
        interactkey.SetActive(false);
        StartCoroutine(CoinRoutin());
        StartCoroutine(bullionRoutin());
    }
}