using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosssceneUI : SceneUI
{
    [SerializeField] private Bosshp bosshp;
    protected override void Awake()
    {
        base.Awake();
        sliders["Bosshp"].maxValue = bosshp.maxbosshp;
        sliders["Bosshp"].value = bosshp.maxbosshp;


    }
    public void Update()
    {
        sliders["Bosshp"].value = bosshp.bosshp;

    }
}
