using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class inve : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)                                          //자식이 없을경우 그냥들어가고
        {
            GameObject drooped = eventData.pointerDrag;
            itemDarge itemDarge = drooped.GetComponent<itemDarge>();
            itemDarge.partentAfterDarag = transform;
        }
        else
        {
            GameObject drooped = eventData.pointerDrag;                                 //자식이 없는경우 체인지하자
            itemDarge itemDarge = drooped.GetComponent<itemDarge>();
           transform.GetChild(0).gameObject.transform.parent = itemDarge.partentAfterDarag;
            itemDarge.partentAfterDarag = transform;
            
        }
       
    }
}
