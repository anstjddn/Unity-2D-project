using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Attack1Bullet : MonoBehaviour
{
    [SerializeField] public float bulletspeed;
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * bulletspeed);
    }

    
}
