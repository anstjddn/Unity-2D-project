using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRoomppoint : MonoBehaviour
{
   [SerializeField] private GameObject player;
    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }
    private void Start()
    {
        player.transform.position = transform.position;
    }

}
