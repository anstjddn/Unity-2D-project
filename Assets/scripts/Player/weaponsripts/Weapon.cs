using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;
using static Weapon;

public class Weapon: MonoBehaviour
{
 
    public enum weapontype { sword,gun};
    private weapontype curtype;
    public bool isattack;                          //공격속도 여부로 딜레이준다.


    [SerializeField] Vector2 boxsize;                   //어택 범위 어택범위 holad기준으로 하면되징낳ㅇ르가?
    [SerializeField] LayerMask monster;                     //맞을수있는애들


    //equipment 창에 있는 현재 무기 불러와서 쓰기
        GameObject curweapon; 

    //칼일떄
      [SerializeField] GameObject slasheffect;                   
       [SerializeField] public int dagame;                           
      [SerializeField] GameObject hiteffect;                         
       public float attackdalay;                          
      public Vector2 weaponposition;
    [SerializeField] Transform swordAttackpoint;

    //총일떄
    [SerializeField] GameObject bulletprefabs;
    [SerializeField] Transform bulletpoint;
    public void Update()
    {
        curweapon = GetComponent<player2euipment>().curweapon;
        if (curweapon.GetComponent<sword>() != null)
        {
            dagame = curweapon.GetComponent<sword>().data.damage;
            slasheffect = curweapon.GetComponent<sword>().data.slasheffectprefabs;
            hiteffect = curweapon.GetComponent<sword>().data.hiteffctprefabs;
            attackdalay = curweapon.GetComponent<sword>().data.attackdelay;
            swordAttackpoint = curweapon.transform.GetChild(0).gameObject.transform;
            curtype = weapontype.sword;
            
        }
       else if (curweapon.GetComponent<gun>() != null)
        {
            dagame = curweapon.GetComponent<gun>().data.damage;
            bulletprefabs = curweapon.GetComponent<gun>().data.bulletprefabs;
            attackdalay = curweapon.GetComponent<gun>().data.attackdelay;
            hiteffect = null;
            slasheffect = null;
            curtype = weapontype.gun;
            bulletpoint = curweapon.transform.GetChild(0).gameObject.transform;
        }
     
    }

    public void Attack()
    {
      if(curtype == weapontype.sword&& !isattack)
        {
            StartCoroutine(swordhiteffctroutin(attackdalay));
        }
       if (curtype == weapontype.gun && !isattack)
        {
            StartCoroutine(gunattack(attackdalay));
        }


    }
   
    IEnumerator swordhiteffctroutin(float attackdalay)
    {
        isattack = true;
        Instantiate(hiteffect, swordAttackpoint.position, transform.rotation);                     //이거 임펙트 방향
        Collider2D[] colliders = Physics2D.OverlapBoxAll(swordAttackpoint.transform.position, boxsize, 0, monster);
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

    IEnumerator gunattack(float attackdaley)
    {
        isattack = true;
        Instantiate(bulletprefabs, bulletpoint.position, bulletpoint.rotation);
        Destroy(slasheffect, 5f);
        yield return new WaitForSeconds(attackdaley);
        isattack = false;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(swordAttackpoint.transform.position, boxsize);
    }
}
