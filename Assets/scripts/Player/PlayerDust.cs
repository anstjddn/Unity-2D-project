using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDust : MonoBehaviour
{

    [SerializeField] Transform player;
    private Animator dustanim;

    private void Awake()
    {
        dustanim = GetComponent<Animator>();
        player = GetComponent<Transform>();

    }

    private void Update()
    {
        if(player.transform.position.magnitude ==0)
        {
            
            dustanim.SetBool("move", false);
        }
        else dustanim.SetBool("move", true);
    }
}
