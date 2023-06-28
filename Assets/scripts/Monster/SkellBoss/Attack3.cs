using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class Attack3 : MonoBehaviour
{
    [SerializeField] public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            IHitable hitable = collision.GetComponent<IHitable>();
            hitable?.TakeHit(damage);
        }
    }
}

