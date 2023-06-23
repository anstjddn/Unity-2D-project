using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Playercurcoin : MonoBehaviour
{
    [SerializeField] public TMP_Text cointext;



    private void Awake()
    {
        cointext = GetComponent<TMP_Text>();

    }

    private void Update()
    {
        cointext.text = ($"{GameManager.data.basegold}");

    }
}
