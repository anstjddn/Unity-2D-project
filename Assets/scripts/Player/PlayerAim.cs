using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerAim : MonoBehaviour

{
    [SerializeField] GameObject aimcursor;
    [SerializeField] Transform WeaponHoledpoint;
    [SerializeField] GameObject hiteffect;

    Vector2 aimpos;

   
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
        Attack();

    }
    private void Attack()
    {
       
        StartCoroutine(hiteffctroutin());
    }

    IEnumerator hiteffctroutin()
    {
      
        Instantiate(hiteffect, hiteffect.transform.position, hiteffect.transform.rotation);

        yield return null;
    }
}
