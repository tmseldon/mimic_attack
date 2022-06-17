using Game.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] float _initPitch = 1f;
        [SerializeField] float _modPitch = 0.8f;

        AudioSource _audioSource;
        PlayerPreferences _playerConfig;

        // Start is called before the first frame update
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _playerConfig = FindObjectOfType<PlayerPreferences>();

            _playerConfig.ChangeSoundConfig += ChangeSoundLevel;
            _audioSource.volume = _playerConfig.GetVolumeLevel();
        }

        private void OnDestroy()
        {
            _playerConfig.ChangeSoundConfig -= ChangeSoundLevel;
        }

        public void ChangePitchMusic(bool changePitch)
        {
            if (changePitch)
            {
                _audioSource.pitch = _modPitch;
            }
            else
            {
                _audioSource.pitch = _initPitch;
            }
        }

        public void StopOST()
        {
            _audioSource.Stop();
        }

        public void PauseOST()
        {
            _audioSource.Pause();
        }

        public void PlayOST()
        {
            _audioSource.Play();
        }

        private void ChangeSoundLevel(object sender, float newVolume)
        {
            _audioSource.volume = newVolume;
        }
    }

}
