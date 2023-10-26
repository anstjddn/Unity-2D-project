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
                if (items.iteminfos[i].sworddata !=null)
                {
                    slot.texts.text = $"Damega: {items.iteminfos[i].sworddata.damage} Attackdalay : {items.iteminfos[i].sworddata.attackdelay}";
                }
                if (items.iteminfos[i].gundata != null)
                {
                    slot.texts.text = $"Damega: {items.iteminfos[i].gundata.damage} ShootCount : {items.iteminfos[i].gundata.shootcount}";
                  
                }

                slots.Add(slot);
            }
            else return;
        }
    }
}
