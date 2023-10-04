using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adroom : MonoBehaviour
{
    private roomTemplates spsp;
    public bool isclear;
    private void Awake()
    {
        spsp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<roomTemplates>();
        spsp.rooms.Add(this.gameObject);
    }
}
