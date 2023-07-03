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
            //���߿� �˾� ui�ϸ�ȴ�
            bossui.SetActive(true);
        }
    }
}
