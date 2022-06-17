using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    public class BatteryPickup : MonoBehaviour
    {
        [SerializeField] float angleRestore = 60f;
        [SerializeField] float intensityRestore = 6f;
        [SerializeField] AudioClip pickupFX;

        private void OnTriggerEnter(Collider other)
        {
            FlashLightSystem flashLight = other.gameObject.GetComponentInChildren<FlashLightSystem>();
            flashLight.RestoreLightAngle(angleRestore);
            flashLight.RestoreLightIntensity(intensityRestore);
            AudioSource.PlayClipAtPoint(pickupFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }

}