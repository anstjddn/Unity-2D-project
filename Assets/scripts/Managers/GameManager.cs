using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private static DataManager dataManager;


    public static GameManager Instance { get { return instance; } }
    public static DataManager data { get { return dataManager; } }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
            InitManagers();
        }
        
    }
    private void OnDestroy()
    {
        if (instance == this)
            instance = null;
    }

    private void InitManagers()
    {
       GameObject dataobj = new GameObject();
        dataobj.name = "DataManager";
        dataobj.transform.parent = transform;
        dataManager = dataobj.AddComponent<DataManager>();
       

    }
}
