using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : BaseUI
{
    protected override void Awake()
    {
        base.Awake();
        texts["playercoin"].text= GameManager.data.BaseGold.ToString();
    }

    public void Update()
    {
        texts["curcoin"].text = GameManager.data.BaseGold.ToString();
    }
}
