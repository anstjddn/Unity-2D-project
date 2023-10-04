using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roomcheck : MonoBehaviour
{
    public RoomState roomState;
    [SerializeField] public GameObject minimapobj;

    public void Awake()
    {
        roomState = GetComponentInParent<RoomState>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            roomState.isclear = true;
            minimapobj.SetActive(true);
        }
    }
}
