using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ITemBox : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject interactkey; //F키
    [SerializeField] GameObject Coinobj;
    [SerializeField] GameObject Bullionobj;
    private int coinmoney;
    private int bullionmoney;

    private void Awake()
    {
        interactkey.SetActive(false);
        anim = GetComponent<Animator>();
        coinmoney = Random.Range(30, 50);
        bullionmoney = Random.Range(10, 12);

    }
    private void OnTriggerEnter2D(Collider2D collision)             //상호작용 ㄹ키
    {
        if (collision.gameObject.layer ==6)
        {
            interactkey.SetActive(true);
        }
        
      /* if (interactkey != null)
        {
            interactkey.SetActive(true);
        }
        else
        {
            interactkey.SetActive(false);
        }*/

       
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {

        interactkey.SetActive(false);

    }

    public void Interact()
    {
        
        anim.SetBool("Hit", true);
        Destroy(interactkey);
        StartCoroutine(CoinRoutin());
        StartCoroutine(bullionRoutin());
      



    } 
    //나오는돈갯수조절
    IEnumerator CoinRoutin()
    {
        while (coinmoney > 0)
        {
            Instantiate(Coinobj, transform.position, Quaternion.identity);
            
            coinmoney--;
        }
        yield return null;
    }
    IEnumerator bullionRoutin()
    {
        while (bullionmoney > 0)
        {
            Instantiate(Bullionobj, transform.position, Quaternion.identity);

            bullionmoney--;
        }
        yield return null;
    }



}