using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class InventoryMark : MonoBehaviour
{

    public player2euipment cureq;
    public void Awake()
    {   
        for (int i = 0; i < 2; i++)
        {
            transform.GetChild(i).name = $"euip{i}mark";

        }

    }
    private void Update()
    {
        if (cureq.weapons[0].gameObject.activeSelf == true)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
        if (cureq.weapons[0].gameObject.activeSelf == false)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(true);
        }
    }

}
