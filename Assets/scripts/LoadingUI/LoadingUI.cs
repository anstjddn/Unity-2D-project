using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingUI : MonoBehaviour
{
    private Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeOut()
    {
        anim.SetBool("Active", true);
    }

    public void FadeIn()
    {
        anim.SetBool("Active", false);
    }
}
