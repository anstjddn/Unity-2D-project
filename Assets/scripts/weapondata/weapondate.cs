using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu (fileName = "sworddata", menuName = "Data/sword")]
public class weapondate : ScriptableObject
{

  [SerializeField] public string name;
  [SerializeField]  public int damage;
  [SerializeField]  public GameObject hiteffctprefabs;
  [SerializeField]  public GameObject swodrobj;
  [SerializeField]  public GameObject slasheffectprefabs;
  [SerializeField] public float attackdelay;
  [SerializeField] public Sprite sprite;

}




