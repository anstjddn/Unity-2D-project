using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventoryeqip : MonoBehaviour
{
    [SerializeField] public GameObject equip1;
    [SerializeField] public GameObject equip2;

    [SerializeField] public bool isequip1;
    [SerializeField] public bool isequip2;
    public void Update()
    {
        if(equip1.transform.childCount != 0)
        {
            isequip1 = true;
        }
        else
        {
            isequip1 = false;
        }

        if (equip2.transform.childCount != 0)
        {
            isequip2 = true;
        }
        else
        {
            isequip2 = false;
        }

    }
}
