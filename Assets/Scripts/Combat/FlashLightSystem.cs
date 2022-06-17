using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    public class FlashLightSystem : MonoBehaviour
    {
        [SerializeField] float lightDecay = 0.1f;
        [SerializeField] float angleDecay = 0.2f;
        [SerializeField] float minimunAngle = 40f;

        Light myFlashLight;

        void Start()
        {
            myFlashLight = GetComponent<Light>();
        }

        void Update()
        {
            DecreaseLightAngle();
            DecreaseLightIntensity();
        }

        public void RestoreLightAngle(float restoreAngle)
        {
            myFlashLight.spotAngle = restoreAngle;
        }

        public void RestoreLightIntensity(float amountIntensity)
        {
            myFlashLight.intensity += amountIntensity;
        }


        private void DecreaseLightAngle()
        {
            if (myFlashLight.spotAngle <= minimunAngle)
            {
                return;
            }

            myFlashLight.spotAngle -= angleDecay * Time.deltaTime;
        }

        private void DecreaseLightIntensity()
        {
            if (myFlashLight.intensity <= 0)
            {
                return;
            }

            myFlashLight.intensity -= lightDecay * Time.deltaTime;
        }
    }

}
