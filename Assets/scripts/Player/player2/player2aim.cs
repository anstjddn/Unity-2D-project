using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player2aim : MonoBehaviour
{
   
        [SerializeField] public GameObject aimcursor;
        [SerializeField] public Transform WeaponHoledpoint;
    [SerializeField] public Weapon weapon;
        Vector2 aimpos;

        private void LateUpdate()
        {
            WeaponHoledpoint.transform.right = new Vector2(aimcursor.transform.position.x - WeaponHoledpoint.transform.position.x, aimcursor.transform.position.y - WeaponHoledpoint.transform.position.y);
            aimcursor.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(aimpos.x, aimpos.y, 10));
        }
        private void OnPointer(InputValue value)
        {
            aimpos.x = value.Get<Vector2>().x;
            aimpos.y = value.Get<Vector2>().y;
        }
        
     private void OnAttack()
    {
        if (weapon.curweapon!=null)
         Attack();
    }
    public void Attack()
    {
        transform.GetComponentInChildren<Weapon>().Attack();
    }
    
  

}
