using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class box : MonoBehaviour, IPointerEnterHandler
{
    private Rigidbody2D rb;
    //private Renderer renderer;
    [SerializeField] Color mouse;

    public void OnPointerEnter(PointerEventData eventData)
    {
       // renderer.material.color = mouse;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
      //  renderer = GetComponent<Renderer>();
    }
}
