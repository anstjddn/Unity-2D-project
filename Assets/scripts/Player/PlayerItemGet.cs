using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerItemGet : MonoBehaviour
{
    [SerializeField] Transform playerarea;
    [SerializeField] Vector3 areasize;
    [SerializeField] LayerMask getable;
 //   [SerializeField] LayerMask dashdam;
   // [SerializeField] public bool isdash;

   
    private void Update()
    {
       // isdash = GetComponent<PlayerController>().isdashing;

        Collider2D[] colliders = Physics2D.OverlapBoxAll(playerarea.position, areasize, 0, getable);
        foreach (Collider2D collider in colliders)
        {

            IGetable Getable = collider.GetComponent<IGetable>();
            Getable?.Get();
        }
    
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(playerarea.position, areasize);
    }
}
