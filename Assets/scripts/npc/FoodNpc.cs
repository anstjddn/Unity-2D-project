using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class FoodNpc : MonoBehaviour,Iinteractable
{
    private Animator anim;
    [SerializeField] GameObject interactkey; //F키
    [SerializeField] GameObject FoodUI;
    private GameObject player;
    private bool isui;
    private void Awake()
    {
        interactkey.SetActive(false);
        anim = GetComponent<Animator>();
        FoodUI.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)             //상호작용 ㄹ키
    {
        if (collision.gameObject.layer == 6)
        {
            interactkey.SetActive(true);
            player = collision.gameObject;
        }



    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        interactkey.SetActive(false);
        player = null;

    }

    public void interact()
    {
        if (!FoodUI.activeSelf)
        {
            FoodUI.SetActive(true);
            SoundManager.Instance.PlayeBGM("shop");
            player.GetComponent<PlayerInput>().enabled = false;
        }   
    }
    public void Escinteract()
    {
        player.GetComponent<PlayerInput>().enabled = true;
        FoodUI.SetActive(false);
        SoundManager.Instance.StopBgm();
        SoundManager.Instance.PlayeBGM("Dungeon");
    }

}
