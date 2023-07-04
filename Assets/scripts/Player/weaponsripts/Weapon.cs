using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


public class Weapon: MonoBehaviour
{
    [SerializeField] GameObject hiteffect;          //����Ʈ
    public float attackdalay;                       //���ݼӵ�����
    public bool isattack;                          //���ݼӵ� ����

    Vector2 effectpos;
    [SerializeField] Vector2 boxsize;                   //���� ���� ���ù��� holad�������� �ϸ��¡��������?
    [SerializeField] public int dagame;                     //������    

    [SerializeField] LayerMask monster;                     //�������ִ¾ֵ�
    [SerializeField] GameObject slasheffect;                //�´¾ֵ�ȿ��

    public Vector2 weaponposition;
    public void Awake()
    {
        weaponposition = new Vector2(transform.parent.position.x, transform.parent.position.y + 0.75f);//������ ����
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
