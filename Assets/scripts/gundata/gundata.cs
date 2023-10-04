using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "gundata", menuName = "Data/gun")]
    public class gundata : ScriptableObject
    {

        [SerializeField] public string gunname;
        [SerializeField] public int damage;
        [SerializeField] public int shootcount;
        [SerializeField] public GameObject hiteffctprefabs;
        [SerializeField] public GameObject gunprefabs;
        [SerializeField] public GameObject bulletprefabs;
        [SerializeField] public float attackdelay;
        [SerializeField] public Sprite sprite;
        [SerializeField] public int realoadtime;

    }

