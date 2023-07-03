using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossstartpoint : MonoBehaviour
{
    [SerializeField] public GameObject bossui;

    private void Awake()
    {
        bossui.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            //나중에 팝업 ui하면된다
            bossui.SetActive(true);
        }
    }
}
