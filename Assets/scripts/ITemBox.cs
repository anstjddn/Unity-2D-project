using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ITemBox : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject interactkey; //FŰ
    [SerializeField] GameObject Coinobj;
    [SerializeField] GameObject Bullionobj;
    private int coinmoney;
    private int bullionmoney;

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }
    private void OnTriggerEnter2D(Collider2D collision)             //��ȣ�ۿ� ��Ű
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

// �͸��ϸ� ��������� ������������ A has B A�� B�� �����ϰ��ִ°��  ���������� ����� ����������
// ��������� A use B B�� �Ű������� ����ҋ� ��� ���������� ex)B�� ��� A�� ���ư��� ex �÷��̾� ���� ���
// �Ϲ�ȭ ���� = ���
// ��üȭ ���� = �������̽�
// �ռ����� = ������Ʈ ���� a�� ������ b�� ������
// ������� = �������϶� a�� �������� b�� ���´�