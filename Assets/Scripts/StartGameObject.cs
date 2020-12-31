using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync(2,LoadSceneMode.Additive);
        StateManager.currentScene = SceneManager.GetSceneByBuildIndex(2);
        StateManager.endNewLevelEvent?.Invoke();
        StateManager.winEvent?.Invoke();
        Destroy(gameObject);
    }
}
