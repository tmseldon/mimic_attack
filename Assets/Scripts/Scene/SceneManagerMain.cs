using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.SceneControl
{
    public class SceneManagerMain : MonoBehaviour
    {
        [SerializeField] string _firstLevelName;

        private const string MAIN_MENU = "MainMenu";
        private const string CONFIG_MENU = "ConfigMenu";
        private const string INFO = "Instructions";

        public void GoToMain() => SceneManager.LoadScene(MAIN_MENU);
        public void GoToConfig() => SceneManager.LoadScene(CONFIG_MENU);
        public void GoToInfo() => SceneManager.LoadScene(INFO);
        public void GoToFirstLevel() => SceneManager.LoadScene(_firstLevelName);
        public void QuitGame() => Application.Quit();
    }
}

