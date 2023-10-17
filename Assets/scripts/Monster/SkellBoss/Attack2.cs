using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class Attack2 : MonoBehaviour
{
    [SerializeField] public int damage = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.activeSelf&&collision.gameObject.layer == 6)
        {
            IHitable hitable = collision.GetComponent<IHitable>();
            hitable?.TakeHit(damage);
        }
    }
}
