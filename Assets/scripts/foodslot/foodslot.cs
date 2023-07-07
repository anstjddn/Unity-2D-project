using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class foodslot : MonoBehaviour
{
   
    [SerializeField]public Transform slotRoot;
    public List<meum> slots;
    public FoodData fooddata;
    public int rand;

   public void Awake()
    {
        
         slots = new List<meum>();
            int slotcunt = slotRoot.childCount;

            for (int i = 0; i < slotcunt; i++)
            {
                var slot = slotRoot.GetChild(i).GetComponent<meum>();
                 
                 slot.name = fooddata.foods[i].name;                     
                 slot.money= fooddata.foods[i].price;
                 slot.meumimage = fooddata.foods[i].foodimage;
                 slot.hpheal = fooddata.foods[i].hpheal;
                 slot.maxhp = fooddata.foods[i].maxhp;
                   slots.Add(slot);
              }
        
   }
    
}
