using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2 : MonoBehaviour
{
    [SerializeField] public int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            IHitable hitable = collision.GetComponent<IHitable>();
            hitable?.TakeHit(damage);
        }
    }
}
