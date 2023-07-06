using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "itemdata", menuName = "Data/item")]
public class item : ScriptableObject
{
    public List<iteminfo> iteminfos;


    [Serializable]
    public class iteminfo
    {
        public string name;
        public int damage;
        public int shootcount;
        public GameObject hittpreabs;
        public GameObject gunobj;
        public GameObject bulletprefabs;
        public float attackdalay;
        public Sprite sprite;
        public int realoading;

    }
    

}
