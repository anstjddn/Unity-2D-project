using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1BulletLeft : MonoBehaviour
{
    [SerializeField] public float bulletspeed;
    void Update()
    {
        transform.Translate(-transform.right * Time.deltaTime * bulletspeed);
    }

}
