using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class shopslot : MonoBehaviour
{
    public Transform slotRoot;
    public itembuffer itembuffer;
    public List<Slot> slots;

    public Action<itemproperty> onslotcliked;

    public void Start()
    {
        slots = new List<Slot>();
        int slotcunt = slotRoot.childCount;

        for(int i=0; i < slotcunt; i++)
        {
            var slot = slotRoot.GetChild(i).GetComponent<Slot>();

            if(i< itembuffer.items.Count)
            {
                slot.Setitem(itembuffer.items[i]);
            }

            slots.Add(slot);
        }
    }
    public void Onclickslot(Slot slot)
    {
        if (onslotcliked != null)
        {
            onslotcliked(slot.item);
        }
    }
}
