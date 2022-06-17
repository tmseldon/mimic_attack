using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class DisplayDamage : MonoBehaviour
    {
        [SerializeField] Canvas attackDamage;

        // Transform of the camera to shake. Grabs the gameObject's transform
        // if null.
        [SerializeField] Transform camTransform;

        // How long the object should shake for.
        [SerializeField] float shakeDuration = 0.2f;
        [SerializeField] float damageFXDuration = 0.3f;
        float shakeDurationOriginal = 0;

        // Amplitude of the shake. A larger value shakes the camera harder.
        [SerializeField] float shakeAmount = 0.3f;
        [SerializeField] float decreaseFactor = 1.0f;

        Vector3 originalPos;
        bool isShaking = false;

        private void Start()
        {
            attackDamage.enabled = false;
            originalPos = camTransform.localPosition;
            shakeDurationOriginal = shakeDuration;
        }

        public void ShowDamageFX()
        {
            StartCoroutine(ShowDamageCanvas());
            isShaking = true;
        }

        private void Update()
        {
            ShakeCamera();
        }

        private void ShakeCamera()
        {
            if (isShaking)
            {
                if (shakeDuration > 0)
                {
                    camTransform.localPosition = originalPos + UnityEngine.Random.insideUnitSphere * shakeAmount;

                    shakeDuration -= Time.deltaTime * decreaseFactor;
                }
                else
                {
                    isShaking = false;
                    shakeDuration = shakeDurationOriginal;
                    camTransform.localPosition = originalPos;
                }
            }
        }

        IEnumerator ShowDamageCanvas()
        {
            attackDamage.enabled = true;
            yield return new WaitForSeconds(damageFXDuration);
            attackDamage.enabled = false;
        }
    }
}