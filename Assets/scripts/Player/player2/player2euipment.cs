using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player2euipment : MonoBehaviour
{
 
    public List<GameObject> weapons = new List<GameObject>();
    public GameObject curweapon;

    public void Awake()
    {
        for(int i = 0; i < 2; i++)
        {
            GameObject Weapon = transform.GetChild(i).gameObject;
            weapons.Add(Weapon);
            weapons[i].SetActive(false);
        }
        curweapon = weapons[0];
    }

    public void Update()
    {
        curweapon.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            curweapon.SetActive(false);
            curweapon = weapons[0];

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            curweapon.SetActive(false);
            curweapon = weapons[1];
        }


    }


}
