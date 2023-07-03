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
        anim.SetTrigger("attack");
        Instantiate(bulletprefabs,transform.position,Quaternion.identity);
        Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0,0,45));
        Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0, 0, -45));
        Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0, 0, -90));
        Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0, 0, -135));
      
        Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0, 0, 90));
        Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0, 0, 135));
        Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0, 0, 180));
        yield return new WaitForSeconds(5f);
        isattack = false;
    }
}
