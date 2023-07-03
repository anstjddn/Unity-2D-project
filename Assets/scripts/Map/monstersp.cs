using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class monstersp : MonoBehaviour
{
    [SerializeField] public GameObject door;
    public UnityEvent dunin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            Debug.Log("몬스터 스폰 포인트");
            dunin?.Invoke();
        }
        
    }
}
