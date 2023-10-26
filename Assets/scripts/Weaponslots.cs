using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weaponslots : MonoBehaviour
{
    [SerializeField] public GameObject weaponhold;
    [SerializeField] public Image weapon1;
    private void Awake()
    {
        weapon1 = transform.GetComponent<Image>();
    }
 /*   private void Update()
    {
        if (weaponhold.transform.GetChild(0) != null)
        {
            transform.GetComponent<Image>().color = new Color(255, 255, 255, 1);
            weapon1.sprite = weaponhold.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;

        }
        else
        {
            transform.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }
    }*/
}
