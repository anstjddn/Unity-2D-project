using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon: MonoBehaviour
{
 
    public enum weapontype { sword,gun};
    private weapontype curtype;
    public bool isattack;                          //공격속도 여부로 딜레이준다.


    [SerializeField] Vector2 boxsize;                   //어택 범위 어택범위 holad기준으로 하면되징낳ㅇ르가?
    [SerializeField] LayerMask monster;                     //맞을수있는애들


    //equipment 창에 있는 현재 무기 불러와서 쓰기
   public    GameObject curweapon;

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
    [SerializeField] int bulletcount;
    public bool isreloading;
    public int reloadingtime;


    public void Update()                //무기 바뀔거 염려해서 update에 올려놈
    {
        if (curweapon == null)
        {
            isattack = false;
        }
        curweapon = GetComponent<player2euipment>().curweapons.transform.GetChild(0).gameObject;
        if (curweapon.GetComponent<sword>() != null)                                //현재 무기가 칼이면
        {
            dagame = curweapon.GetComponent<sword>().data.damage;
            GameManager.data.playerDamege = dagame;
            slasheffect = curweapon.GetComponent<sword>().data.slasheffectprefabs;
            hiteffect = curweapon.GetComponent<sword>().data.hiteffctprefabs;
            attackdalay = curweapon.GetComponent<sword>().data.attackdelay;
            GameManager.data.playerattackspeed = attackdalay;
            swordAttackpoint = curweapon.transform.GetChild(0).gameObject.transform;
            curtype = weapontype.sword;
            bulletpoint = null;
            bulletprefabs = null;


        }
        else if (curweapon.GetComponent<gun>() != null)                             // 현재 무기가 총이면
        {
            hiteffect = null;            //칼꺼
            slasheffect = null;         //칼꺼
            swordAttackpoint = null;    //칼꺼



            dagame = curweapon.GetComponent<gun>().data.damage;
            GameManager.data.playerDamege = dagame;
            bulletprefabs = curweapon.GetComponent<gun>().data.bulletprefabs;
            attackdalay = curweapon.GetComponent<gun>().data.attackdelay;
            GameManager.data.playerattackspeed = attackdalay;
            curtype = weapontype.gun;
            bulletpoint = curweapon.transform.GetChild(0).gameObject.transform;
            reloadingtime = curweapon.GetComponent<gun>().data.realoadtime;
        }

    }


    public void Attack()
    {
      if(curtype == weapontype.sword&& !isattack)
        {
            SoundManager.Instance.PlaySFX("PlayerAttack");
            StartCoroutine(swordhiteffctroutin(attackdalay));
        }
       if (curtype == weapontype.gun && !isattack&& !isreloading)
        {
            StartCoroutine(gunattack(attackdalay));
        }
        if (isreloading)
        {
            StopCoroutine(gunattack(attackdalay));
            StartCoroutine(reloadingrouine(reloadingtime));
        }

    }
   
    IEnumerator swordhiteffctroutin(float attackdalay)
    {
        isattack = true;
       
        GameObject hit =GameManager.Pool.Get(hiteffect, swordAttackpoint.position, transform.rotation);                     //이거 임펙트 방향
        Collider2D[] colliders = Physics2D.OverlapBoxAll(swordAttackpoint.transform.position, boxsize, 0, monster);
        foreach (Collider2D collider in colliders)
        {

            IHitable hitable = collider.GetComponent<IHitable>();
            hitable.TakeHit(dagame);
            GameObject slashefect = GameManager.Pool.Get(slasheffect, collider.transform.position, Quaternion.Euler(0, 0, 120));
            StartCoroutine(ReleaseRoutine(0.5f, slashefect));
        //    Destroy(slasheffect, 0.5f);
        }
        yield return new WaitForSeconds(attackdalay);
        GameManager.Pool.Release(hit);
        isattack = false;
        
    }

    IEnumerator gunattack(float attackdaley)
    {
        isreloading = false;
        isattack = true;
        int weaponcount = curweapon.GetComponent<gun>().data.shootcount;
        bulletcount++;
       GameObject bulletefect = GameManager.Pool.Get(bulletprefabs, bulletpoint.position, bulletpoint.rotation);
    //  Instantiate(bulletprefabs, bulletpoint.position, bulletpoint.rotation);
       // Destroy(slasheffect, 5f);
        yield return new WaitForSeconds(attackdaley);
        isattack = false;
        if (bulletcount == weaponcount)
        {
            isreloading = true;
        }
    }
    IEnumerator reloadingrouine(int reloadingtime)
    {
       // curweapon.GetComponent<gun>().Reloading();
        yield return new WaitForSeconds(reloadingtime);
        bulletcount = 0;
        isreloading = false;
        // 리로딩 이미지 넣자
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(swordAttackpoint.transform.position, boxsize);
    }
    IEnumerator ReleaseRoutine(float Time,GameObject obj)
    {
        yield return new WaitForSeconds(Time);
        GameManager.Pool.Release(obj);
    }
}
