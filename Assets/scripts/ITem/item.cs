using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "itemdata", menuName = "Data/item")]
public class item : ScriptableObject
{
   
  //  public List<iteminfo> iteminfos;
    public iteminfo[] iteminfos;

    [Serializable]
    public class iteminfo
    {
        public string name;
        public weapondate sworddata;
        public gundata gundata;
        public Sprite sprite;
    }


   

}
