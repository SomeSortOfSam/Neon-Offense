using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainMenu
{
    public class StartButton : Button
    {
        public void OnStartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}

