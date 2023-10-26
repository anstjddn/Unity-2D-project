using Cinemachine.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="fooddata",menuName ="Data/food")]
public class FoodData : ScriptableObject
{
    public List<Foodinfo> foods;

    [Serializable]
    public class Foodinfo
    {
        public int price;
        public string name;
        public int hpheal;
        public int maxhp;
        public int curfood;
        public Sprite foodimage;

    }

}
