using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class FoodUI : BaseUI
{
    protected override void Awake()
    {
        base.Awake();
        sliders["foodbar"].maxValue = GameManager.data.maxfood;
        sliders["foodbar"].value = GameManager.data.curfood;
        texts["foodbartext"].text = $"{GameManager.data.curfood}/{GameManager.data.maxfood}";
        texts["palyercurcoin"].text = $"{GameManager.data.BaseGold}";
        buttons["ShopUIEse"].onClick.AddListener(() => SoundManager.Instance.PlayeBGM("Dungeon"));
    }

    public void Update()
    {
        sliders["foodbar"].value = GameManager.data.curfood;
        texts["palyercurcoin"].text = $"{GameManager.data.BaseGold}";
    }
}
