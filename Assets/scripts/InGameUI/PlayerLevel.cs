using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
  
    [SerializeField] public TMP_Text leveltext;


    private void Awake()
    {
       
        leveltext = GetComponent<TMP_Text>();
    }

    private void Update()
    {
      
        leveltext.text = ($"{GameManager.data.playerLevel}");
    }
}
