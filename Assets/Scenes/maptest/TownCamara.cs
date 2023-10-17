using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownCamara : MonoBehaviour
{
    public GameObject vituralCam;
    public Transform player;

    void Start()
    {
        player = GameObject.FindObjectOfType<Player>().gameObject.transform.GetChild(0).gameObject.transform;
        vituralCam.GetComponent<CinemachineVirtualCamera>().Follow = player;
        vituralCam.GetComponent<CinemachineVirtualCamera>().LookAt = player;
    }

}
