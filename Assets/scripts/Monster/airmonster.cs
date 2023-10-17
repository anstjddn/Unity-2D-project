using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class airmonster : MonoBehaviour
{
    [SerializeField] Transform playerpos;
    private Animator anim;
    Vector2 playerdir;
    private bool isattack;
    [SerializeField] GameObject bulletprefabs;
    private void Awake()
    {
        playerpos = GameObject.FindWithTag("Player").transform;
         anim = GetComponent<Animator>();
    }
    public void Update()
    {
        if(!isattack &&Vector2.Distance(playerpos.position, transform.position) < 5)
        {
            StartCoroutine(attackroutin());
        }
    }
   

    IEnumerator attackroutin()
    {
        isattack = true;
        SoundManager.Instance.PlaySFX("BansheeAttack");
        anim.SetTrigger("attack");
      GameObject Bansgeeattack= GameManager.Pool.Get(bulletprefabs,transform.position,Quaternion.identity);
        StartCoroutine(ReleseRoutine(Bansgeeattack, 5f));
     //   Destroy(Bansgeeattack, 5f);
       GameObject Bansgeeattack2 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0,0,45));
        StartCoroutine(ReleseRoutine(Bansgeeattack2, 5f));
        GameObject Bansgeeattack3 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0, 0, -45));
        StartCoroutine(ReleseRoutine(Bansgeeattack3, 5f));
        GameObject Bansgeeattack4 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0, 0, -90));
        StartCoroutine(ReleseRoutine(Bansgeeattack4, 5f));
        GameObject Bansgeeattack5 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0, 0, -135));
        StartCoroutine(ReleseRoutine(Bansgeeattack5, 5f));
        GameObject Bansgeeattack6 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0, 0, 90));
        StartCoroutine(ReleseRoutine(Bansgeeattack6, 5f));
        GameObject Bansgeeattack7 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0, 0, 135));
        StartCoroutine(ReleseRoutine(Bansgeeattack7, 5f));
        GameObject Bansgeeattack8 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0, 0, 180));
        StartCoroutine(ReleseRoutine(Bansgeeattack8, 5f));
        yield return new WaitForSeconds(5f);
        isattack = false;
    }

    IEnumerator ReleseRoutine(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Pool.Release(obj);
    }
}
