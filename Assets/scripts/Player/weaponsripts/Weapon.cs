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
    public bool isattack;                          //���ݼӵ� ���η� �������ش�.


    [SerializeField] Vector2 boxsize;                   //���� ���� ���ù��� holad�������� �ϸ��¡��������?
    [SerializeField] LayerMask monster;                     //�������ִ¾ֵ�


    //equipment â�� �ִ� ���� ���� �ҷ��ͼ� ����
        GameObject curweapon; 

    //Į�ϋ�
      [SerializeField] GameObject slasheffect;                   
       [SerializeField] public int dagame;                           
      [SerializeField] GameObject hiteffect;                         
       public float attackdalay;                          
      public Vector2 weaponposition;
    [SerializeField] Transform swordAttackpoint;

    //���ϋ�
    [SerializeField] GameObject bulletprefabs;
    [SerializeField] Transform bulletpoint;
    [SerializeField] int bulletcount;
    public bool isreloading;
    public int reloadingtime;


    private void OnEnable()
    {      
    }


    public void Update()
    {
        curweapon = GetComponent<player2euipment>().curweapon;
        if (curweapon.GetComponent<sword>() != null)                                //���� ���Ⱑ Į�̸�
        {
            dagame = curweapon.GetComponent<sword>().data.damage;
            GameManager.data.playerDamege = dagame;
            slasheffect = curweapon.GetComponent<sword>().data.slasheffectprefabs;
            hiteffect = curweapon.GetComponent<sword>().data.hiteffctprefabs;
            attackdalay = curweapon.GetComponent<sword>().data.attackdelay;
            GameManager.data.playerattackspeed = attackdalay;
            swordAttackpoint = curweapon.transform.GetChild(0).gameObject.transform;
            curtype = weapontype.sword;
            
        }
       else if (curweapon.GetComponent<gun>() != null)                             // ���� ���Ⱑ ���̸�
        {
            dagame = curweapon.GetComponent<gun>().data.damage;
            GameManager.data.playerDamege = dagame;
            bulletprefabs = curweapon.GetComponent<gun>().data.bulletprefabs;
            attackdalay = curweapon.GetComponent<gun>().data.attackdelay;
            GameManager.data.playerattackspeed = attackdalay;
            hiteffect = null;
            slasheffect = null;
            curtype = weapontype.gun;
            bulletpoint = curweapon.transform.GetChild(0).gameObject.transform;         
            reloadingtime = curweapon.GetComponent<gun>().data.realoadtime;
        }
     
    }

    public void Attack()
    {
      if(curtype == weapontype.sword&& !isattack)
        {
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
       
        Instantiate(hiteffect, swordAttackpoint.position, transform.rotation);                     //�̰� ����Ʈ ����
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
        isreloading = false;
        isattack = true;
        bulletcount--;
        Instantiate(bulletprefabs, bulletpoint.position, bulletpoint.rotation);
        Destroy(slasheffect, 5f);
        yield return new WaitForSeconds(attackdaley);
        isattack = false;
        if (bulletcount == 0)
        {
            isreloading = true;
        }
    }
    IEnumerator reloadingrouine(int reloadingtime)
    {
        bulletcount = curweapon.GetComponent<gun>().data.shootcount;
     
        yield return new WaitForSeconds(reloadingtime);
        isreloading = false;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(swordAttackpoint.transform.position, boxsize);
    }
}
