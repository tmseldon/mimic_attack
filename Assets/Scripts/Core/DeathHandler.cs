using Game.Combat;
using Game.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    public class DeathHandler : MonoBehaviour
    {
        [SerializeField] Canvas deathScreen;
        [SerializeField] AudioClip deathFX;
        [SerializeField][Range(0f, 1f)] float volume = 0.5f;

        MusicManager musicManager;

        // Start is called before the first frame update
        void Start()
        {
            deathScreen.enabled = false;
            musicManager = FindObjectOfType<MusicManager>();
        }

        public void HandleDeath()
        {
            deathScreen.enabled = true;
            Time.timeScale = 0;

            FindObjectOfType<WeaponSwitcher>().enabled = false;
            FindObjectOfType<DisplayDamage>().enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            musicManager.StopOST();
            AudioSource.PlayClipAtPoint(deathFX, Camera.main.transform.position, volume);
        }
    }

}
