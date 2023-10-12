using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    private LoadingUI LoadingUI;
    [SerializeField]private bool isis;

    private void Awake()
    {
        LoadingUI ui = GameManager.Resource.Load<LoadingUI>("UI/LoadingUI");
        LoadingUI = Instantiate(ui);
        LoadingUI.transform.SetParent(transform);
    }
    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadingRoutine(sceneName));
    }

    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAsyncRoutine(sceneName));
    }

    IEnumerator LoadingRoutine(string sceneName)
    {
        LoadingUI.FadeOut();
        yield return new WaitForSeconds(0.5f);

        UnitySceneManager.LoadScene(sceneName);

        LoadingUI.FadeIn();
        yield return new WaitForSeconds(0.5f);
    }
    IEnumerator LoadSceneAsyncRoutine(string sceneName)
    {

        AsyncOperation oper = UnitySceneManager.LoadSceneAsync(sceneName);
        LoadingUI.FadeOut();
        yield return new WaitForSeconds(0.5f);

  
        while (!oper.isDone)
        {
            yield return null;
        }


        if (roomTemplates.Gameroom.alladd)
        {
        
            LoadingUI.FadeIn();
            isis = true;
        }   

    }
}
