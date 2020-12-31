﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(1,LoadSceneMode.Additive);
        StateManager.currentScene = SceneManager.GetSceneByBuildIndex(1);
        StateManager.endNewLevelEvent?.Invoke();
        StateManager.winEvent?.Invoke();
        Destroy(gameObject);
    }
}