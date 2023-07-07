using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class itemDarge : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public Transform partentAfterDarag;
    public void Awake()
    {
        image = GetComponent<Image>();
        
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        partentAfterDarag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        transform.SetParent(partentAfterDarag);
        image.raycastTarget = true ;
    }
}
