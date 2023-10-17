using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownScene : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Resource.Instantiate<GameObject>("Player/Player", Vector3.zero, Quaternion.identity);
        SoundManager.Instance.PlayeBGM("Town");
    }
}
