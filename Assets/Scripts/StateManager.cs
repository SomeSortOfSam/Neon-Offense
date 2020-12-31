using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StateManager
{
    public static bool lost = false;
    public static Action loseEvent;
    public static Action winEvent;
    public static Action startNewLevelEvent;
    public static Action endNewLevelEvent;
    public static Scene currentScene;

    public static void Lose()
    {
        loseEvent?.Invoke();
        lost = true;
    }

    public static void Win()
    {
        if(!lost)
        {
            winEvent?.Invoke();
        }
    }

    public static void LoadNextScene()
    {
        LoadScene(currentScene.buildIndex + 1);
    }

    public static void RestartGame()
    {
        LoadScene(1);
    }

    public static void LoadScene(int buildIndex)
    {
        startNewLevelEvent?.Invoke();
        AsyncOperation Unload = SceneManager.UnloadSceneAsync(currentScene,UnloadSceneOptions.None);
        AsyncOperation Load = SceneManager.LoadSceneAsync(buildIndex,LoadSceneMode.Additive);
        currentScene = SceneManager.GetSceneByBuildIndex(buildIndex);
        endNewLevelEvent?.Invoke();
    }
}