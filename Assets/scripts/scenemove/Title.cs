using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{

    public void Awake()
    {
        SoundManager.Instance.PlayeBGM("Town");
    }
    public void ChangeScene(string scenename)
    {
        GameManager.Scene.LoadScene(scenename);
    }


}
