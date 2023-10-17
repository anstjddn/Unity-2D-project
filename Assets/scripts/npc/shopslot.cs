    using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class shopslot : MonoBehaviour
{
    public Transform slotRoot;

    public List<Slot> slots;
    public item items;

    public void Start()
    {
        slots = new List<Slot>();
        int slotcunt = slotRoot.childCount;

        for (int i = 0; i < slotcunt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();


            if (items.iteminfos[i] != null)
            {
                slot.name = items.iteminfos[i].name;
                slot.imageobj.name = items.iteminfos[i].name;
                slot.image.sprite = items.iteminfos[i].sprite;

                slots.Add(slot);
            }
            else return;
        }
    }
}
