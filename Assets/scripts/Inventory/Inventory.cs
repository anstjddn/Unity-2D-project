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
        slots = new List<Slot>();      //lost�� ���� 
        int slotcunt = slotRoot.childCount;

        for (int i = 0; i < slotcunt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();                           //�κ��丮 ����
            slot.name = $"inventory{i}";
            slots.Add(slot);
        }
    }
 
    public void Buyitem(GameObject obj)
    {

       GameObject moveobj = Instantiate(obj);
       // Destroy(obj);
        Debug.Log("���̰�");
        /* for (int i = 0; i < slots.Count; i++)
         {
             if (slots[i].transform.GetChild(0) == null)                 //���°��
             {

                 moveobj.transform.SetParent(slots[i].transform);
                 Debug.Log($"{obj.name} slots{i}�������"); //���� �ְ�
             }
             else
             {
                 return;
             }*/
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].transform.childCount == 0)                 //���°��
            {
                Debug.Log($"{obj.name} slots{i}�������");

                moveobj.transform.SetParent(slots[i].transform);
                moveobj.AddComponent<itemDarge>();
                return;
                //Debug.Log($"{obj.name} slots{i}�������"); //���� �ְ�
            }
          
    }
    }

   // void Buyitem(itemproperty item)                                                         //����ִ½��� ã�Ƽ� �־��ش�
  /*  { var emptySlot = slots.Find(t =>
          {
              return t.item == null || t.item.name == string.Empty;
          });

          if(emptySlot != null)
          {
              emptySlot.Setitem(item);
          }*/

    }

