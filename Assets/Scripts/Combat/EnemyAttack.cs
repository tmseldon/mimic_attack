using Game.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Combat
{
    public class EnemyAttack : MonoBehaviour
    {
        PlayerHealth target;
        [SerializeField] float damage = 40f;
        [SerializeField] AudioClip enemyAttackFX;

        void Start()
        {
            target = FindObjectOfType<PlayerHealth>();
        }

        public void EnemyAttackHitEvent()
        {
            if (target == null) { return; }

            target.PlayerTakeDamage(damage);
            AudioSource.PlayClipAtPoint(enemyAttackFX, Camera.main.transform.position);
        }

        public void OnDamageTaken()
        {
            return;
            //Debug.Log("I also know that I was attacked");
        }
    }

}