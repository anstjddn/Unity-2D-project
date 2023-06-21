using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHpBar : MonoBehaviour
{
    [SerializeField] public TMP_Text hptext;
   


    private void Awake()
    {
        hptext = GetComponent<TMP_Text>();
        
    }

    private void Update()
    {
        hptext.text = ($"{GameManager.data.curHp}/{GameManager.data.maxHp}");
     
    }
  
}
