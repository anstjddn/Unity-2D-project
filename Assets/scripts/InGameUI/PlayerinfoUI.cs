using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerinfoUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();
        texts["playerLevel"].text = GameManager.data.playerLevel.ToString();
        texts["playerhpbar"].text = ($"{GameManager.data.curHp}/{GameManager.data.maxHp}");
        sliders["playerhpslider"].maxValue = GameManager.data.maxHp;
        sliders["playerhpslider"].value = GameManager.data.curHp;
        texts["curcoin"].text = GameManager.data.basegold.ToString();
        texts["curfood"].text = GameManager.data.curfood.ToString();
   
    }
    public void Update()
    {
        texts["playerLevel"].text = GameManager.data.playerLevel.ToString();
        texts["playerhpbar"].text = ($"{GameManager.data.curHp}/{GameManager.data.maxHp}");
        sliders["playerhpslider"].maxValue = GameManager.data.maxHp;
        sliders["playerhpslider"].value = GameManager.data.curHp;
        texts["curcoin"].text = GameManager.data.basegold.ToString();
        texts["curfood"].text = GameManager.data.curfood.ToString();
    }
}
