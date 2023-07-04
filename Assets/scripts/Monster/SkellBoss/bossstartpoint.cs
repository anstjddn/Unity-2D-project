using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class bossstartpoint : MonoBehaviour
{
    [SerializeField] public GameObject bossui;
    [SerializeField]public UnityEvent Onboosplayed;
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
            Onboosplayed?.Invoke();
        }
    }
}
