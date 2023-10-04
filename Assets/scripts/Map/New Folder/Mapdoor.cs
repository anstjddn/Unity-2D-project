using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mapdoor : MonoBehaviour
{
    public RoomState roomState;
    private Animator dooranim;
   
    public void Awake()
    {
        roomState = GetComponentInParent<RoomState>();
        dooranim = GetComponent<Animator>();
    }
    //����Ŭ����
    public void Open()
    {
        dooranim.SetBool("end", true);
    }
    public void Close()
    {
        dooranim.SetBool("start", true);
    }

}
