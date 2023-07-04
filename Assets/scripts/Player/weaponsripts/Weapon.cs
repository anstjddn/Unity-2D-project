using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Weapon: MonoBehaviour
{
    [SerializeField] GameObject hiteffect;
    public float attackdalay;
    Vector2 effectpos;
    public bool isattack;
    [SerializeField] float range;
    Vector2 aimpos;
    [SerializeField] Vector2 boxsize;
    [SerializeField] Transform attackpoint;
    [SerializeField] public int dagame;

    [SerializeField] LayerMask monster;
    [SerializeField] GameObject slasheffect;

    public void Update()
    {
        effectpos = new Vector2(transform.position.x, transform.position.y);
    }

    private void Attack()
    {

        StartCoroutine(hiteffctroutin(attackdalay));

    }

    IEnumerator hiteffctroutin(float attackdalay)
    {
        isattack = true;
        Instantiate(hiteffect, effectpos, Quaternion.identity);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(attackpoint.position, boxsize, 0, monster);
        foreach (Collider2D collider in colliders)
        {

            IHitable hitable = collider.GetComponent<IHitable>();
            hitable.TakeHit(dagame);
            Instantiate(slasheffect, collider.transform.position, Quaternion.Euler(0, 0, 120));
            Destroy(slasheffect, 0.5f);
        }
        yield return new WaitForSeconds(attackdalay);
        isattack = false;

    }
}
