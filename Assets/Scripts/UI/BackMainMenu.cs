using Game.SceneControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    [RequireComponent(typeof(Button))]
    public class BackMainMenu : MonoBehaviour
    {
        Button _buttonBack;
        MainMenu _mainMenu;

        private void Start()
        {
            _mainMenu = FindObjectOfType<MainMenu>();
            _buttonBack = GetComponent<Button>();
            _buttonBack.onClick.AddListener(_mainMenu.BackToMainMenu);
        }
    }

}
