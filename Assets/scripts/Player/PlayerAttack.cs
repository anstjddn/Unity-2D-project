using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] public GameObject hold;
    [SerializeField] public GameObject[] weaponslot;
    [SerializeField] public GameObject curweapon;

    public void Awake()
    {
        
        curweapon = weaponslot[0];

    }
    public void Update()
    {
        if(curweapon == weaponslot[0])
        {
            weaponslot[0].SetActive(true);
            weaponslot[1].SetActive(false);
        }
        else
        {
            weaponslot[0].SetActive(false);
            weaponslot[1].SetActive(true);
        }


        if (Input.GetKey(KeyCode.Q))
        {
            curweapon = weaponslot[0];
        }
        if (Input.GetKey(KeyCode.E))
        {
            curweapon = weaponslot[1];
        }
    }
}
