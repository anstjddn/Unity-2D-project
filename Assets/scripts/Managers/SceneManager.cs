using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

public class SceneManager : MonoBehaviour
{
    public LoadingUI LoadingUI;
    public BaseScene curScene;

    public BaseScene CurScene
    {
        get
        {
            if (curScene == null)
                curScene = GameObject.FindObjectOfType<BaseScene>();

            return curScene;
        }
    }

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
        if (CurScene != null)
        {
            CurScene.LoadAsync();
            while (!CurScene.isclear)
            {
                Debug.Log("루프도는중");
                yield return null;
            }
            Debug.Log("완료");
            LoadingUI.FadeIn();
        }
        yield return new WaitForSeconds(0.5f);

    }
}
