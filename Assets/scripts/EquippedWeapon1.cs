using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquippedWeapon1 : MonoBehaviour
{
    public GameObject cur1eq;
    public Sprite curim;
  
    
    private void Update()
    {
        cur1eq = GetComponent<player2euipment>().curweapons;
        if(cur1eq.GetComponent<sword>() != null)            //소드일경우
        {
            curim = cur1eq.GetComponent<sword>().data.sprite;
        }
        else
        {
            return;
        }
    }
}
