using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UPdownpotal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            collision.transform.position += transform.up * 30f;
        }
    }
}
