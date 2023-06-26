using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Floor : MonoBehaviour
{
    private PlatformEffector2D playform;

    private void Awake()
    {
        playform = GetComponent<PlatformEffector2D>();
    }
}
