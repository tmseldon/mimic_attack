using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    public class Ammo : MonoBehaviour
    {
        [SerializeField] AmmoSlot[] ammoSlots;

        [System.Serializable]
        private class AmmoSlot
        {
            public AmmoType ammoType;
            public int ammoAmount;
        }

        public int GetCurrentAmmo(AmmoType typeOfAmmo)
        {
            AmmoSlot determineSlot = GetAmmoSlot(typeOfAmmo);
            return determineSlot.ammoAmount;
        }

        public void ReduceCurrentAmmo(AmmoType typeOfAmmo)
        {
            AmmoSlot determineSlot = GetAmmoSlot(typeOfAmmo);
            determineSlot.ammoAmount--;
        }

        public void IncreaseCurrentAmmo(AmmoType typeOfAmmo, int amountToAdd)
        {
            AmmoSlot determineSlot = GetAmmoSlot(typeOfAmmo);
            determineSlot.ammoAmount += amountToAdd;
        }

        private AmmoSlot GetAmmoSlot(AmmoType typeOfAmmo)
        {
            foreach (AmmoSlot slot in ammoSlots)
            {
                if (slot.ammoType == typeOfAmmo)
                {
                    return slot;
                }
            }

            return null;

        }
    }

}