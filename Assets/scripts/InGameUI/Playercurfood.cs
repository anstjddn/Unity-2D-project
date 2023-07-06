using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Playercurfood : MonoBehaviour
{
    [SerializeField] public TMP_Text foodtext;
    [SerializeField] Slider slider;
    

    private void Awake()
    {
        foodtext = GetComponent<TMP_Text>();

    }

    private void Update()
    {
        foodtext.text = ($"{GameManager.data.curfood}/{GameManager.data.maxfood}");

        if(slider!= null)
        {
            slider.value = GameManager.data.curfood;
       


        }

    }
}
