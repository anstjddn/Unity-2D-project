using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Transform slotRoot;
    public shopslot shop;
    public List<Slot> slots;

    public GameObject image;
    public void Start()
    {
        slots = new List<Slot>();
        int slotcunt = slotRoot.childCount;

        for (int i = 0; i < slotcunt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();                           //인벤토리 설정
            slot.name = $"inventory{i}";
            slots.Add(slot);
        }
                                         
    }

   // void Buyitem(itemproperty item)                                                         //비어있는슬롯 찾아서 넣어준다
  /*  { var emptySlot = slots.Find(t =>
          {
              return t.item == null || t.item.name == string.Empty;
          });

          if(emptySlot != null)
          {
              emptySlot.Setitem(item);
          }*/

       
        /*   public void getitem(item item)
           {
               for(int i =0; i < slots.Count; i++)
               {
                   if (slots[i].transform.GetChild(0) == null)
                   {
                       item.itemImage = slots[i].transform.GetChild(0);
                   }
               }
           }*/
    }

