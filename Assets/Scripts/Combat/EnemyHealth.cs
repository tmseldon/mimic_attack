using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] float healthEnemy = 100f;
        [SerializeField] AudioClip deathEnemyFX;

        Animator animatorController;
        EnemyIA enemyIA;
        Collider colliderEnemy;

        bool isDead = false;

        private void Start()
        {
            animatorController = GetComponent<Animator>();
            enemyIA = GetComponent<EnemyIA>();
            colliderEnemy = GetComponent<Collider>();
        }

        public void TakeDamage(float amount)
        {
            BroadcastMessage("OnDamageTaken");
            healthEnemy -= amount;

            if (healthEnemy <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (isDead) { return; }

            animatorController.SetTrigger("isDead");
            AudioSource.PlayClipAtPoint(deathEnemyFX, Camera.main.transform.position);
            enemyIA.Shutdown();
            colliderEnemy.enabled = false;
            isDead = true;
        }
    }

}