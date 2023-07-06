using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class meum : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{

      public int money;

    [SerializeField] public Sprite meumimage;                
    [SerializeField] public Image foodimage;
    [SerializeField] public int hpheal;
    [SerializeField] public int maxhp;
    private bool buy;

    public void Awake()
    {
        foodimage.color = new UnityEngine.Color(0, 0, 0, 0);
    }

    private void OnEnable()
    {
        GameManager.data.OnBaseGoldChanged += UpdateUI;
    }

    private void OnDisable()
    {
        GameManager.data.OnBaseGoldChanged -= UpdateUI;
    }

    public void UpdateUI()
    {
        if (GameManager.data.BaseGold < money || buy)
        {
            transform.GetComponent<Button>().interactable = false;
        }
        else
        {
            transform.GetComponent<Button>().interactable = true;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       
        if (GameManager.data.BaseGold >= money&& !buy)
        {
           
            buy = true;
            GameManager.data.BaseGold -= money;
            GameManager.data.curHp += hpheal;
            GameManager.data.maxHp += maxhp;
            foodimage.color = new UnityEngine.Color(255, 255, 255, 0);
            Debug.Log("ªÚ¥Ÿ");
            transform.GetComponent<Button>().interactable = false;
           


        }
        if(GameManager.data.BaseGold < money && !buy)
        {
            Debug.Log("∏¯ªÔ");
          // transform.GetComponent<Button>().spriteState.selectedSprite;
        }
        if (buy)
        {
            
            Debug.Log("¿ÃπÃªÔ");
            return;
        }    
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buy)
        {
            foodimage.color = new UnityEngine.Color(255, 255, 255, 0);
        }
        else
        {
            foodimage.color = new UnityEngine.Color(255, 255, 255, 1);
            foodimage.sprite = meumimage;
            Debug.Log("OnPointerEnter");

        }


    }


    public void OnPointerExit(PointerEventData eventData)
    {
        foodimage.color = new UnityEngine.Color(255, 255, 255, 0);

    }

}
