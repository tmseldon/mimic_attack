using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    public class AmmoPickup : MonoBehaviour
    {
        [SerializeField] int addAmountAmmo = 5;
        [SerializeField] AmmoType ammoType;
        [SerializeField] AudioClip pickupFX;

        private void OnTriggerEnter(Collider other)
        {
            Ammo ammoPlayer = other.GetComponent<Ammo>();
            ammoPlayer.IncreaseCurrentAmmo(ammoType, addAmountAmmo);
            AudioSource.PlayClipAtPoint(pickupFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }

}
