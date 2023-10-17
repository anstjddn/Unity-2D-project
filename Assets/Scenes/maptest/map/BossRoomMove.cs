using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomMove : MonoBehaviour,Iinteractable
{

    [SerializeField] public GameObject interationobj;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            interationobj.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            interationobj.SetActive(false);
        }
    }

    public void BossMove()
    {
        GameManager.Scene.LoadScene("BossScene");
    }

    public void interact()
    {
        BossMove();
    }
}
