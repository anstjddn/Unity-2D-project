using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dest : MonoBehaviour
{

    [SerializeField] public LayerMask layer;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("sppoint"))
        {
            Destroy(other.gameObject);
            Debug.Log("ÆÄ±«µÊ");
        }
        
    }
}
