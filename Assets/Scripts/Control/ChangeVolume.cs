using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Control
{
    public class ChangeVolume : MonoBehaviour
    {
        private Slider _sliderMusic;
        private PlayerPreferences _playerConfig;

        // Start is called before the first frame update
        void Start()
        {
            _sliderMusic = GetComponent<Slider>();
            _playerConfig = FindObjectOfType<PlayerPreferences>();

            _sliderMusic.value = _playerConfig.GetVolumeLevel();
            _sliderMusic.onValueChanged.AddListener(delegate { ChangeTheVolume(_sliderMusic.value); });

        }

        private void ChangeTheVolume(float powervolume)
        {
            _playerConfig.SetVolumeLevel(powervolume);
        }
    }

}

