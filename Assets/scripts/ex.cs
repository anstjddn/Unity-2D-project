using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class ex : MonoBehaviour
{
    public int op;
    public bool opeing;
   

    public ex2 ex3;

    public void Start()
    {
        
        ex3 = GameObject.FindGameObjectWithTag("Rooms").GetComponent<ex2>();
        ep();
    }
    public void ep()
    {
        if(op == 1&& !opeing)
        {
            Instantiate(ex3.rig[0], transform.position, Quaternion.identity);
            opeing = true;
         
        }
    
    }
}

