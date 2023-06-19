using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dungeonin : MonoBehaviour
{
    private Animator inanim;

    private void Awake()
    {
        inanim = GetComponent<Animator>();
    }
    private void animplay()
    {
        inanim.SetTrigger("isplay");
    }
    
}
