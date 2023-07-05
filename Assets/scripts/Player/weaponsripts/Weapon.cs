using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Weapon: MonoBehaviour
{
 
    public bool isattack;                          //���ݼӵ� ���η� �������ش�.

    Vector2 effectpos;
    [SerializeField] Vector2 boxsize;                   //���� ���� ���ù��� holad�������� �ϸ��¡��������?
    [SerializeField] LayerMask monster;                     //�������ִ¾ֵ�

    

     [SerializeField] public int dagame;                     //������          //�̰� ����ҵ尡 �������־����
     [SerializeField] GameObject slasheffect;                //�´¾ֵ�ȿ��     //�̰� ����ҵ尡 �������־����

      [SerializeField] GameObject hiteffect;          //����Ʈ                   //�̰� ����ҵ尡 �������־����
       public float attackdalay;                       //���ݼӵ�����            //�̰� ����ҵ尡 �������־����
       public Vector2 weaponposition;

        player2euipment curep;
        GameObject curwa;

    public void Awake()
    {
        // �̰� ���� ���� �����ϸ� �ȴ� �׷��� �и� ���� ������ �ϳ��� �� �����ض�
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
        Instantiate(hiteffect, effectpos, transform.rotation);                     //�̰� ����Ʈ ����
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
