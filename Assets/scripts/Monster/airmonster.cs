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
    private void OnEnable()
    {
        isattack = false;
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
       GameObject Bansgeeattack2 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0,0,45));
        GameObject Bansgeeattack3 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0, 0, -45));
        GameObject Bansgeeattack4 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0, 0, -90));
        GameObject Bansgeeattack5 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0, 0, -135));
        GameObject Bansgeeattack6 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0, 0, 90));
        GameObject Bansgeeattack7 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0, 0, 135));
        GameObject Bansgeeattack8 = GameManager.Pool.Get(bulletprefabs, transform.position, Quaternion.Euler(0, 0, 180));
        yield return new WaitForSeconds(5f);
        isattack = false;
    }

    IEnumerator ReleseRoutine(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        GameManager.Pool.Release(obj);
    }
}
