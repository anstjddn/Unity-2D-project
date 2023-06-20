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
        anim = GetComponent<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D collision)             //상호작용 ㄹ키
    {
       if (interactkey != null)
        {
            interactkey.SetActive(true);
        }
        else return;
       
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
     
       if (interactkey != null)
          {
              interactkey.SetActive(false);
          }
          else return;

    }

    public void Interact()
    {
        
        anim.SetBool("Hit", true);
        Destroy(interactkey);
        coinmoney = Random.Range(5, 7);
       
        bullionmoney = Random.Range(1, 3);
        StartCoroutine(CoinRoutin());
        StartCoroutine(bullionRoutin());
       
    } 
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

// 왤만하면 멤버변수로 가지고잇으면 A has B A가 B를 포함하고있는경우  직접연관된 관계는 끊을수없음
// 의존관계는 A use B B를 매개변수로 사용할떄 사용 끊을수있음 ex)B가 없어도 A가 돌아갈때 ex 플레이어 몬스터 경우
// 일반화 관계 = 상속
// 실체화 관계 = 인터페이스
// 합성관계 = 컴포넌트 관계 a를 몼스면 b도 못쓴다
// 집약관계 = 독립적일때 a가 없어져도 b는 남는다