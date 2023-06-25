using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Playercurfood : MonoBehaviour
{
    [SerializeField] public TMP_Text foodtext;



    private void Awake()
    {
        foodtext = GetComponent<TMP_Text>();

    }

    private void Update()
    {
        foodtext.text = ($"{GameManager.data.curfood}/{GameManager.data.maxfood}");

    }
}
