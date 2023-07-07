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
        slots = new List<Slot>();      //lost을 담을 
        int slotcunt = slotRoot.childCount;

        for (int i = 0; i < slotcunt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();                           //인벤토리 설정
            slot.name = $"inventory{i}";
            slots.Add(slot);
        }
    }
 
    public void Buyitem(GameObject obj)
    {

       GameObject moveobj = Instantiate(obj);
       // Destroy(obj);
        Debug.Log("들이감");
        /* for (int i = 0; i < slots.Count; i++)
         {
             if (slots[i].transform.GetChild(0) == null)                 //없는경우
             {

                 moveobj.transform.SetParent(slots[i].transform);
                 Debug.Log($"{obj.name} slots{i}비어있음"); //여기 넣고
             }
             else
             {
                 return;
             }*/
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].transform.childCount == 0)                 //없는경우
            {
                Debug.Log($"{obj.name} slots{i}비어있음");

                moveobj.transform.SetParent(slots[i].transform);
                moveobj.AddComponent<itemDarge>();
                return;
                //Debug.Log($"{obj.name} slots{i}비어있음"); //여기 넣고
            }
          
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

    }

