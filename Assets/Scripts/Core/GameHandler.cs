using Game.Combat;
using Game.SceneControl;
using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] Canvas _menuScreen;
        [SerializeField] Canvas _endScreen;
        [SerializeField] AudioClip _pauseFX;
        [SerializeField] AudioClip _portalFX;
        [SerializeField][Range(0f, 1f)] float _volume = 0.5f;

        private MusicManager _musicManager;
        private WeaponSwitcher _weaponSwitch;
        private DisplayDamage _displayDamage;

        private bool _isPause = false;
        public bool IsPause { get { return _isPause; } }

        // Start is called before the first frame update
        void Start()
        {
            _menuScreen.enabled = false;
            _endScreen.enabled = false;

            _musicManager = FindObjectOfType<MusicManager>();
            _weaponSwitch = FindObjectOfType<WeaponSwitcher>();
            _displayDamage = FindObjectOfType<DisplayDamage>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !_isPause)
            {
                _isPause = true;
                GetPauseMenu();
            }
        }

        private void GetPauseMenu()
        {
            AudioSource.PlayClipAtPoint(_pauseFX, Camera.main.transform.position, _volume);
            _menuScreen.enabled = true;
            ToogleSystems(false);
            _musicManager.PauseOST();
        }

        public void ResumeGame()
        {
            _menuScreen.enabled = false;
            ToogleSystems(true);
            _musicManager.PlayOST();
            _isPause = false;
        }

        public void BackToMainMenu()
        {
            ToogleSystems(true);
            FindObjectOfType<SceneLoader>().GoToMainMenu();
        }

        public void FinishGame()
        {
            AudioSource.PlayClipAtPoint(_portalFX, Camera.main.transform.position, _volume);
            _endScreen.enabled = true;
            ToogleSystems(false);
            _musicManager.PauseOST();
        }

        private void ToogleSystems(bool status)
        {
            _weaponSwitch.enabled = status;
            _displayDamage.enabled = status;

            if (status)
            {
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

}
