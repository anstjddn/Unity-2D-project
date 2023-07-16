using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weaponslots2 : MonoBehaviour
{
    [SerializeField] public GameObject weaponhold;
    [SerializeField] public Image weapon2;
    private void Awake()
    {
        weapon2 = transform.GetComponent<Image>();
    }
    private void Update()
    {
        if (weaponhold.transform.GetChild(1) != null)
        {
            transform.GetComponent<Image>().color = new Color(255, 255, 255, 1);
            weapon2.sprite = weaponhold.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite;

        }
        else
        {
            transform.GetComponent<Image>().color = new Color(255, 255, 255, 0);
        }
    }
}
