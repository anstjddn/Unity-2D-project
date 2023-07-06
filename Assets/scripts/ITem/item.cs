using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "itemdata", menuName = "Data/item")]
public class item : ScriptableObject
{
    public string itemname;
    public string itemdese;
    public Sprite itemImage;
    public GameObject itemPrefabs;

}
