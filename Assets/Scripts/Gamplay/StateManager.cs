using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    public static StateManager instance;
    public static bool lost = false;
    public GameObject winObject;
    public CanvasGroup loseImage;
    public Vector3 winObjectSpawnPos;

    public static Action loseEvent;
    public static Action winEvent;

    public static void Lose(int health)
    {
        if(health < 0)
        {
            Lose();
        }
    }
    public static void Lose()
    {
        loseEvent?.Invoke();
        lost = true;
        instance.StartCoroutine("LoseCorutine");
    }

    private System.Collections.IEnumerator LoseCorutine()
    {
        float time = 0;
        while(time < 1)
        {
            loseImage.alpha = time;
            time += .01f;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public static void Win()
    {
        if(!lost)
        {
            winEvent?.Invoke();
            instance.winObject.SetActive(true);
        }
    }

    private void Start()
    {
        instance = this;
        lost = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(winObjectSpawnPos, .1f);
    }
}