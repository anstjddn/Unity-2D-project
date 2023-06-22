using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField] public TMP_Text hptext;
    [SerializeField] public Slider HpSlider;
   


    private void Awake()
    {
        hptext = GetComponent<TMP_Text>();

    }

    private void Update()
    {
        hptext.text = ($"{GameManager.data.curHp}/{GameManager.data.maxHp}");
        HpSlider.maxValue = GameManager.data.maxHp;
        HpSlider.value = GameManager.data.curHp;



    }
  
}
