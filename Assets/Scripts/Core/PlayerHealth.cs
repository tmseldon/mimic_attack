using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Game.UI;

namespace Game.Core
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] float playerHP = 100f;
        [SerializeField] TextMeshProUGUI playerHeatlhCanvas;

        DeathHandler deathHandler;
        DisplayDamage displayDamageFX;

        const string HEALTH = "%";

        private void Start()
        {
            deathHandler = GetComponent<DeathHandler>();
            displayDamageFX = GetComponent<DisplayDamage>();

            playerHeatlhCanvas.SetText(playerHP + HEALTH);
        }

        public void PlayerTakeDamage(float amount)
        {
            playerHP -= amount;
            displayDamageFX.ShowDamageFX();
            playerHeatlhCanvas.SetText(playerHP + HEALTH);

            if (playerHP <= 0)
            {
                deathHandler.HandleDeath();
            }

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Finish"))
            {
                FindObjectOfType<GameHandler>().FinishGame();
            }
            else if (other.CompareTag("Death"))
            {
                deathHandler.HandleDeath();
            }
        }
    }

}

