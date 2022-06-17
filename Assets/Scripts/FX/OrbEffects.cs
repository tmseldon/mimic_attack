using Game.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.FX
{
    public class OrbEffects : MonoBehaviour
    {
        [SerializeField] float distanceFX = 10f;

        [SerializeField] float orbIntensityInit = 2.5f;
        [SerializeField] float orbIbtensityFinal = 5f;

        Color32 colorRed = new Color32(214, 25, 36, 255);
        Color32 colorGreen = new Color32(21, 97, 13, 255);
        //Color32 colorGreen = new Color32(61, 214, 25, 255);

        PlayerHealth player;
        ChangePostFX changeFX;
        MusicManager musicManager;
        Light luzOrb;

        bool detectoPlayer = false;

        void Start()
        {
            player = FindObjectOfType<PlayerHealth>();
            luzOrb = GetComponentInChildren<Light>();

            changeFX = FindObjectOfType<ChangePostFX>();
            musicManager = FindObjectOfType<MusicManager>();
        }

        void Update()
        {
            VerificarRango();
        }

        private void VerificarRango()
        {
            float distanciaAJugador = Vector3.Distance(this.transform.position, player.transform.position);

            //Si no esta dentro del rango y el jugador no ha entrado se va a return, caso contrario resetea estados
            if (distanciaAJugador > distanceFX)
            {
                if (detectoPlayer)
                {
                    luzOrb.intensity = orbIntensityInit;
                    luzOrb.color = colorRed;
                    musicManager.ChangePitchMusic(false);
                    changeFX.ChangeStateGrainFX(false);
                    detectoPlayer = false;
                }

                return;
            }

            //Si esta dentro del rango
            luzOrb.intensity = orbIbtensityFinal;
            luzOrb.color = colorGreen;
            musicManager.ChangePitchMusic(true);
            changeFX.ChangeStateGrainFX(true);

            detectoPlayer = true;

        }
    }
}