using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class meum : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{

    public int money = 3000;

    [SerializeField] public GameObject foodimage;
    public bool buy;

    private void Awake()
    {
        foodimage.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.data.basegold > money&& !buy)
        {
        
            buy = true;
            GameManager.data.basegold -= money;
            Debug.Log("»ò´Ù");
           
        }
        if(GameManager.data.basegold < money && !buy)
        {
            Debug.Log("¸ø»ï");
        }
        if (buy)
        {
            Debug.Log("ÀÌ¹Ì»ï");
            return;
        }    
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       
        foodimage.SetActive(true);
        Debug.Log("OnPointerEnter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
   
        foodimage.SetActive(false);

    }

}
