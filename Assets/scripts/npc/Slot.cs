using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Slot : MonoBehaviour //, IPointerClickHandler
{
    public GameObject imageobj;
    public Image image;
    public Inventory invent;
    public Button button;
 
    public void Awake()
    {
        button = GetComponent<Button>();
        imageobj = transform.GetChild(0).gameObject;
      //  button.onClick.AddListener(() => Buy());
      
    }

  /* public void Buy()
  {
        transform.GetChild(0).gameObject.transform.parent = 
   }*/


  /*  public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log("Å¬¸¯µÊ");

    }*/
    
}
