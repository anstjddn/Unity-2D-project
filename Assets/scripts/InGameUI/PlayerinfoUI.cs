using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerinfoUI : SceneUI
{
    [SerializeField] private PlayerController player;
    
    protected override void Awake()
    {
        base.Awake();
        texts["playerLevel"].text = GameManager.data.playerLevel.ToString();
        texts["playerhpbar"].text = ($"{GameManager.data.curHp}/{GameManager.data.maxHp}");
        sliders["playerhpslider"].maxValue = GameManager.data.maxHp;
        sliders["playerhpslider"].value = GameManager.data.curHp;
        texts["curcoin"].text = GameManager.data.BaseGold.ToString();
        texts["curfood"].text = GameManager.data.curfood.ToString();
    }
    public void Update()
    {
        texts["playerLevel"].text = GameManager.data.playerLevel.ToString();
        texts["playerhpbar"].text = ($"{GameManager.data.curHp}/{GameManager.data.maxHp}");
        sliders["playerhpslider"].maxValue = GameManager.data.maxHp;
        sliders["playerhpslider"].value = GameManager.data.curHp;
        texts["curcoin"].text = GameManager.data.BaseGold.ToString();
        texts["curfood"].text = GameManager.data.curfood.ToString();
        images["Weapon1image"].sprite = player.GetComponentInChildren<Weapon>().curweapon.GetComponent<SpriteRenderer>().sprite;
        setcount();

     }

    public void setcount()
    {
        switch (player.dashcount)
        {
            case 2:
                Debug.Log("대시카운터2");
                images["DashCount1"].enabled = true;
                images["DashCount2"].enabled = true;
                break;
            case 1:
                Debug.Log("대시카운터1");
                images["DashCount1"].enabled = true;
                images["DashCount2"].enabled = false;
                break;
            case 0:
                Debug.Log("대시카운터0");
                images["DashCount1"].enabled = false;
                images["DashCount2"].enabled = false;
                break;
        }
    }
}
