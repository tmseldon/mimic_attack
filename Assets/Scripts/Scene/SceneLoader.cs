using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.SceneControl
{
    public class SceneLoader : MonoBehaviour
    {
        private int indexCurrentScene;

        private void Start()
        {
            indexCurrentScene = SceneManager.GetActiveScene().buildIndex;
        }
        public void RestartGame()
        {
            SceneManager.LoadScene(indexCurrentScene);
            Time.timeScale = 1;
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void QuitGame()
        {
            Application.Quit();
        }

    }
}