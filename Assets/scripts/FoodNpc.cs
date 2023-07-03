using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodNpc : MonoBehaviour
{
    private Animator anim;
    [SerializeField] GameObject interactkey; //FŰ
    private void Awake()
    {
        interactkey.SetActive(false);
        anim = GetComponent<Animator>();
      

    }
    private void OnTriggerEnter2D(Collider2D collision)             //��ȣ�ۿ� ��Ű
    {
        if (collision.gameObject.layer == 6)
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

        Debug.Log("��ȣ�ۿ�");

    }
}
