using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseObject : MonoBehaviour
{
    public CanvasGroup loseImage;
    private void Start()
    {
        StateManager.loseEvent += delegate { StartCoroutine("LoseCorutine"); };
    }
    private System.Collections.IEnumerator LoseCorutine()
    {
        float time = 0;
        while (time < 1)
        {
            loseImage.alpha = time;
            time += .01f;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
