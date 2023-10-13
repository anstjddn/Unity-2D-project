using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adroom : MonoBehaviour
{
    private RoomTemplates spsp;
    public bool isclear;
    private void Awake()
    {
        spsp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        spsp.rooms.Add(this.gameObject);
    }
}
