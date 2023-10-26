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
        moveobj.name = obj.name;
    //    Destroy(obj);
 
      
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].transform.childCount == 0)                 //없는경우
            {
              

                moveobj.transform.SetParent(slots[i].transform);
                moveobj.AddComponent<itemDarge>();
                return;
             
            }

            if (slots[14].transform.childCount != 0)
            {
               
                return;
            }
        }
    }
}

