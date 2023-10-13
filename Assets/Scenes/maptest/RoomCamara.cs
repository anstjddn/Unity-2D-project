using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCamara : MonoBehaviour
{
    public GameObject vituralCam;
    public Transform player;

    public void Start()
    {
        player = GameObject.FindObjectOfType<Player>().gameObject.transform.GetChild(0).gameObject.transform;
        vituralCam.GetComponent<CinemachineVirtualCamera>().Follow = player;
        vituralCam.GetComponent<CinemachineVirtualCamera>().LookAt = player;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            vituralCam.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            vituralCam.SetActive(false);
        }
    }
}
