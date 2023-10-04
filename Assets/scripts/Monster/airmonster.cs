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
        anim.SetTrigger("attack");
      GameObject obj1= Instantiate(bulletprefabs,transform.position,Quaternion.identity);
        Destroy(obj1, 5f);
      GameObject obj2= Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0,0,45));
        Destroy(obj2, 5f);
        GameObject obj3=  Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0, 0, -45));
        Destroy(obj3, 5f);
        GameObject obj4 = Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0, 0, -90));
        Destroy(obj4, 5f);
        GameObject obj5 = Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0, 0, -135));
        Destroy(obj5, 5f);
        GameObject obj6 = Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0, 0, 90));
        Destroy(obj6, 5f);
        GameObject obj7 = Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0, 0, 135));
        Destroy(obj7, 5f);
        GameObject obj8 = Instantiate(bulletprefabs, transform.position, Quaternion.Euler(0, 0, 180));
        Destroy(obj8, 5f);
        yield return new WaitForSeconds(5f);
        isattack = false;
    }
}
