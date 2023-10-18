using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoom : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    private bool isenter;
    [SerializeField] private GameObject door;


    private void Awake()
    {
        boss.GetComponent<Bosshp>().Ondeaded += DoorOpen;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6&& !isenter)
        {
            isenter = true;
            SoundManager.Instance.PlayeBGM("BossRoom");
            door.SetActive(true);
            boss.SetActive(true);

            StartCoroutine(CloseRoutine());
        }
    }

    private void DoorOpen()
    {
        StartCoroutine(OpenRoutine());
    }

    IEnumerator CloseRoutine()
    {
        yield return new WaitForSeconds(1f);
        door.GetComponentInChildren<Mapdoor>().Close();
    }

    IEnumerator OpenRoutine()
    {
        yield return new WaitForSeconds(1f);
        door.GetComponentInChildren<Mapdoor>().Open();
    }
    
}
