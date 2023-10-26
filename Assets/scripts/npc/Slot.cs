using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Slot : MonoBehaviour
{
    public GameObject imageobj;
    public Image image;
    public Inventory invent;
    public Button button;
    public TMP_Text texts;
    public void Awake()
    {
        button = GetComponent<Button>();
        imageobj = transform.GetChild(0).gameObject;
        button.onClick.AddListener(() => invent.Buyitem(imageobj));
        button.onClick.AddListener(() => Buyitem());
    }

    public void Buyitem()
    {
        Destroy(gameObject);
    }
}
