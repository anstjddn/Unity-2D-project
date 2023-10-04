using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dest : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer != 18)
        {
            Destroy(other.gameObject);
            Debug.Log("ÆÄ±«µÊ");
        }
        
    }
}
