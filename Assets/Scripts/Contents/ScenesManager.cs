using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoSingleton<ScenesManager>
{
    private string currentSceneName = "";
    public int currentSceneIndex {get; set;}

    private float delay = 0.5f;

    public override void Awake()
    {
        base.Awake();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        currentSceneName = sceneName;
        //currentSceneIndex = 
    }

    public void LoadAsyncSceneAsync(string sceneName)
    {
        currentSceneName = sceneName;
        StartCoroutine(CoLoadAsyncSceneAsync(sceneName));
    }

    IEnumerator CoLoadAsyncSceneAsync(string sceneName)
    {
        yield return null;

        var sceneOperation = SceneManager.LoadSceneAsync(sceneName);
        var loadingPanel = UIManager.Instance.OpenUI<LoadingPanel>();

        float progressRatio = 0f;
        while(!sceneOperation.isDone)
        {
            progressRatio = Mathf.Lerp(progressRatio, sceneOperation.progress, 0.95f);
            loadingPanel.SetProgress(progressRatio);
            Debug.Log(progressRatio);
            if(sceneOperation.progress >= 0.9f)
            {
                UIManager.Instance.CloseUI<LoadingPanel>();
                yield return new WaitForSeconds(delay);
                sceneOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }


    public void UnLoadCurrentScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(currentScene.buildIndex);
    }
}
