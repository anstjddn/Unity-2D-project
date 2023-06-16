using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ITemBox : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();

    }

    public void TakeDamege()
    {
        anim.SetBool("Hit", true);
    } 

}
