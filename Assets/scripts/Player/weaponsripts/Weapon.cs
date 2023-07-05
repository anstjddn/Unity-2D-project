using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Weapon: MonoBehaviour
{
 
    public bool isattack;                          //공격속도 여부로 딜레이준다.

    Vector2 effectpos;
    [SerializeField] Vector2 boxsize;                   //어택 범위 어택범위 holad기준으로 하면되징낳ㅇ르가?
    [SerializeField] LayerMask monster;                     //맞을수있는애들

    

     [SerializeField] public int dagame;                     //데미지          //이건 고스모소드가 가지고있어야함
     [SerializeField] GameObject slasheffect;                //맞는애들효과     //이건 고스모소드가 가지고있어야함

      [SerializeField] GameObject hiteffect;          //임펙트                   //이건 고스모소드가 가지고있어야함
       public float attackdalay;                       //공격속도여부            //이건 고스모소드가 가지고있어야함
       public Vector2 weaponposition;

        player2euipment curep;
        GameObject curwa;

    public void Awake()
    {
        // 이거 상위 폴더 접근하면 된다 그런데 분리 구현 싫으면 하나에 다 구현해라
         dagame = curwa.GetComponent<sword>().data.damage;
        slasheffect = curwa.GetComponent<sword>().data.slasheffectprefabs;
        hiteffect = curwa.GetComponent<sword>().data.hiteffctprefabs;
        attackdalay = curwa.GetComponent<sword>().data.attackdelay;

    }
   public void Update()
    {
       
        dagame = curwa.GetComponent<sword>().data.damage;
        slasheffect = curwa.GetComponent<sword>().data.slasheffectprefabs;
        hiteffect = curwa.GetComponent<sword>().data.hiteffctprefabs;
        attackdalay = curwa.GetComponent<sword>().data.attackdelay;
    }

    public void Attack()
    {
    
      StartCoroutine(hiteffctroutin(attackdalay));

    }
   
    IEnumerator hiteffctroutin(float attackdalay)
    {
        isattack = true;
        Instantiate(hiteffect, effectpos, transform.rotation);                     //이거 임펙트 방향
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, boxsize, 0, monster);
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, boxsize);
    }
}
