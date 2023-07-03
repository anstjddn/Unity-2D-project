using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerAim : MonoBehaviour

{
    [SerializeField] GameObject aimcursor;
    [SerializeField] Transform WeaponHoledpoint;
    [SerializeField] GameObject hiteffect;
    private float attackdalay;

    [SerializeField] float range;
    Vector2 aimpos;
    [SerializeField] Vector2 boxsize;
    [SerializeField] Transform attackpoint;
    [SerializeField] public int dagame;

    [SerializeField] LayerMask monster;
    [SerializeField] GameObject slasheffect;

    public bool isattack;

    private void Awake()
    {
        attackdalay = GameManager.data.playerattackspeed;
        dagame = GameManager.data.playerDamege;
    }
    private void LateUpdate()
    {

        hiteffect.transform.position = WeaponHoledpoint.position;
        hiteffect.transform.up = WeaponHoledpoint.right;

        WeaponHoledpoint.transform.right = new Vector2(aimcursor.transform.position.x - WeaponHoledpoint.transform.position.x, aimcursor.transform.position.y - WeaponHoledpoint.transform.position.y);
        aimcursor.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(aimpos.x, aimpos.y, 10));
    }
    private void OnPointer(InputValue value)
    {
        aimpos.x = value.Get<Vector2>().x;
        aimpos.y = value.Get<Vector2>().y;
    }

    private void OnAttack(InputValue value)
    {
        if (!isattack)
        {
            Attack();
        }

    }
    private void Attack()
    {
       
        StartCoroutine(hiteffctroutin(attackdalay));
       
    }

    IEnumerator hiteffctroutin(float attackdalay)
    {
        isattack = true;
        Instantiate(hiteffect, hiteffect.transform.position, hiteffect.transform.rotation);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(attackpoint.position, boxsize, 0, monster);
        foreach (Collider2D collider in colliders)
        {
          
                IHitable hitable = collider.GetComponent<IHitable>();
                hitable.TakeHit(dagame);
               Instantiate(slasheffect, collider.transform.position, Quaternion.Euler(0,0,120));
            Destroy(slasheffect, 0.5f);
        }
        yield return new WaitForSeconds(attackdalay);
        isattack = false;
    
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(attackpoint.position, boxsize);
    }

 
}
