using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Weapon: MonoBehaviour
{
    [SerializeField] GameObject hiteffect;          //임펙트
    public float attackdalay;                       //공격속도여부
    public bool isattack;                          //공격속도 여부

    Vector2 effectpos;
    [SerializeField] Vector2 boxsize;                   //어택 범위 어택범위 holad기준으로 하면되징낳ㅇ르가?
    [SerializeField] public int dagame;                     //데미지    

    [SerializeField] LayerMask monster;                     //맞을수있는애들
    [SerializeField] GameObject slasheffect;                //맞는애들효과

    public Vector2 weaponposition;
    public void Awake()
    {
        weaponposition = new Vector2(transform.parent.position.x, transform.parent.position.y + 0.75f);//손잡이 위로
        transform.position = weaponposition;
    }
   public void Update()
    {
        effectpos = new Vector2(weaponposition.x+0.5f, weaponposition.y);
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
