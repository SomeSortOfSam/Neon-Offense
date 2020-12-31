using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class StateManager
{
    public static bool lost = false;
    public static Action loseEvent;
    public static Action winEvent;

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
}