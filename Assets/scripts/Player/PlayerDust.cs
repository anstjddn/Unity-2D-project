using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDust : MonoBehaviour
{
    private Animator dustanim;


    private void Awake()
    {
        dustanim = GetComponent<Animator>();
    }
     
}
