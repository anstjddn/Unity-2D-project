using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1BulletUp : MonoBehaviour
{
    [SerializeField] public float bulletspeed;
    void Update()
    {
        transform.Translate(transform.up * Time.deltaTime * bulletspeed);
    }

}
