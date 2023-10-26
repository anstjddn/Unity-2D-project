using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodNpc : MonoBehaviour,Iinteractable
{
    private Animator anim;
    [SerializeField] GameObject interactkey; //FŰ
    [SerializeField] GameObject FoodUI;
    private bool isui;
    private void Awake()
    {
        interactkey.SetActive(false);
        anim = GetComponent<Animator>();
        FoodUI.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)             //��ȣ�ۿ� ��Ű
    {
        if (collision.gameObject.layer == 6)
        {
            interactkey.SetActive(true);
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        interactkey.SetActive(false);

    }

    public void interact()
    {
        if (!FoodUI.activeSelf)
        {
            FoodUI.SetActive(true);
            SoundManager.Instance.PlayeBGM("shop");
        }
    }

}
