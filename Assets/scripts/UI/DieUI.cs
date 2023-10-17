using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieUI : SceneUI
{
    protected override void Awake()
    {
        base.Awake();
        texts["glodText"].text = GameManager.data.BaseGold.ToString();
        texts["TimeText"].text = GameManager.data.playerTime.ToString();
        buttons["ReStartButton"].onClick.AddListener(() => GameManager.Scene.LoadScene("GameScene"));
    }
}
