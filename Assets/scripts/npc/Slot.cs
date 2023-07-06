using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject imageobj;
    public Image image;
    public Inventory invent;

    public void Awake()
    {
        imageobj = transform.GetChild(0).gameObject;
    }
    public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log("Å¬¸¯µÊ");

   
    }
}
