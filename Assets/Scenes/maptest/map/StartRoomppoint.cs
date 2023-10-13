using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoomppoint : MonoBehaviour
{

    [SerializeField] private GameObject player;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>().gameObject.transform.GetChild(0).gameObject;
        player.transform.position = transform.position;
    }

}
