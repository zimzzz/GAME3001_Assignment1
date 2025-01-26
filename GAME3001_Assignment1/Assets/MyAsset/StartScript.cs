using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScript : MonoBehaviour
{
    public void ChangeSceneTo(int sceneIndexToLoad)
    {
        SceneLoader.LoadSceneByIndex(sceneIndexToLoad);
    }
}

public static class SceneLoader
{
    public static void LoadSceneByIndex(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
