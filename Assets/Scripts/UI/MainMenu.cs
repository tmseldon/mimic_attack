using Game.SceneControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class MainMenu : MonoBehaviour
    {
        [Header("Botones")]
        [SerializeField] Button _mainMenu;
        [SerializeField] Button _playGame;
        [SerializeField] Button _infoGame;
        [SerializeField] Button _optionsGame;
        [SerializeField] Button _quitGame;

        [Header("Canvas")]
        [SerializeField] GameObject _groupMain;
        [SerializeField] GameObject _groupConfig;
        [SerializeField] GameObject _groupInstructions;

        private SceneManagerMain _sceneControl;
        private bool _isMainMenu = true;
        private GameObject _menuActiveNow;

        void Start()
        {
            _groupConfig.SetActive(false);
            _groupInstructions.SetActive(false);
            _menuActiveNow = _groupMain;

            _sceneControl = FindObjectOfType<SceneManagerMain>();

            _playGame.onClick.AddListener(_sceneControl.GoToFirstLevel);
            _infoGame.onClick.AddListener(OpenInfoMenu);
            _optionsGame.onClick.AddListener(OpenConfigMenu);
            _quitGame.onClick.AddListener(_sceneControl.QuitGame);

            Time.timeScale = 1;
        }

        private void OpenConfigMenu() => ToogleMenu(true, _groupConfig);
        private void OpenInfoMenu() => ToogleMenu(true, _groupInstructions);
        public void BackToMainMenu() => ToogleMenu(false, _menuActiveNow);

        private void ToogleMenu(bool showMenu, GameObject menu)
        {
            _groupMain.SetActive(!showMenu);
            menu.SetActive(showMenu);

            if(showMenu)
            {
                _menuActiveNow = menu;
            }
            else
            {
                _menuActiveNow = _groupMain;
            }
        }
    }

}

