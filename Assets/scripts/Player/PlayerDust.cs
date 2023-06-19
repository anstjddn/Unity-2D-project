using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDust : MonoBehaviour
{

    [SerializeField] Transform movecheck;
    private Animator dustanim;


    private void Awake()
    {
        dustanim = GetComponent<Animator>();
        movecheck  = GetComponent<Transform>();
        dustanim.SetBool("move", false);
    }

    private void Update()
    {
        if(movecheck.transform.position.magnitude !=0)
        {
            
            dustanim.SetBool("move", true);
        }
    }
}
