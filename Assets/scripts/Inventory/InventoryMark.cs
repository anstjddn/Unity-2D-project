using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor;
using UnityEngine;

public class InventoryMark : MonoBehaviour
{

    public player2euipment eq;
    public void Awake()
    {

        
        for (int i = 0; i < 2; i++)
        {
            transform.GetChild(i).name = $"euip{i}mark";

        }

    }

  
}
