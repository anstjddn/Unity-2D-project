using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class inve : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if(transform.childCount == 0)                                          //�ڽ��� ������� �׳ɵ���
        {
            GameObject drooped = eventData.pointerDrag;
            itemDarge itemDarge = drooped.GetComponent<itemDarge>();
            itemDarge.partentAfterDarag = transform;
        }
        else
        {
            GameObject drooped = eventData.pointerDrag;                                 //�ڽ��� ���°�� ü��������
            itemDarge itemDarge = drooped.GetComponent<itemDarge>();
           transform.GetChild(0).gameObject.transform.parent = itemDarge.partentAfterDarag;
            itemDarge.partentAfterDarag = transform;
            
        }
       
    }
}
