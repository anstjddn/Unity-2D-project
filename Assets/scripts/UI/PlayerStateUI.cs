using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();
        texts["playerpow"].text = GameManager.data.playerDamege.ToString();
        texts["playerdef"].text = GameManager.data.defence.ToString();
        texts["playerblock"].text = GameManager.data.block.ToString();
        texts["playertough"].text = GameManager.data.block.ToString();
        texts["playerattackspeed"].text = GameManager.data.playerattackspeed.ToString();
    }
    public void Update()
    {
        texts["playerpow"].text = GameManager.data.playerDamege.ToString();
        texts["playerdef"].text = GameManager.data.defence.ToString();
        texts["playerblock"].text = GameManager.data.block.ToString();
            texts["playertough"].text = GameManager.data.block.ToString();
        texts["playerattackspeed"].text = GameManager.data.playerattackspeed.ToString();
    }
}
