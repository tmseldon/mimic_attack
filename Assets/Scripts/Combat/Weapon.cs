using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Game.Core;

namespace Game.Combat
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] Camera FPCamera;
        [SerializeField] float range = 100f;
        [SerializeField] float damage = 30f;

        [SerializeField] ParticleSystem muzzle;
        [SerializeField] GameObject hitEffect;
        [SerializeField] float impactEffectTime = 1.5f;
        [SerializeField] float timeBetweenShots = 0.5f;

        [SerializeField] Ammo ammoSlot;
        [SerializeField] WeaponType weaponType;
        [SerializeField] AmmoType ammoType;
        [SerializeField] TextMeshProUGUI ammoTextDisplay;
        [SerializeField] TextMeshProUGUI weaponTextDisplay;

        [SerializeField] AudioClip shotFX;
        [SerializeField][Range(0f, 1f)] float audioShotvolume = 0.8f;

        bool canShoot = true;
        WaitForSeconds waitImpactEffect;
        WaitForSeconds weaponDelayShots;

        GameHandler _gameHandler;

        private void OnEnable()
        {
            canShoot = true;
        }

        private void Awake()
        {
            _gameHandler = FindObjectOfType<GameHandler>();
        }

        private void Start()
        {
            waitImpactEffect = new WaitForSeconds(impactEffectTime);
            weaponDelayShots = new WaitForSeconds(timeBetweenShots);
        }

        void Update()
        {
            DisplayAmmo();
            if (Input.GetMouseButtonDown(0) && canShoot == true && !_gameHandler.IsPause)
            {
                StartCoroutine(Shoot());
            }
        }

        private void DisplayAmmo()
        {
            int ammo = ammoSlot.GetCurrentAmmo(ammoType);
            ammoTextDisplay.SetText(ammo.ToString());
            weaponTextDisplay.SetText(weaponType.ToString());
        }
        IEnumerator Shoot()
        {
            canShoot = false;

            if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
            {
                ApplyMuzzleEffect();
                ProcessRayCast();
                ammoSlot.ReduceCurrentAmmo(ammoType);
                AudioSource.PlayClipAtPoint(shotFX, Camera.main.transform.position, audioShotvolume);
            }

            yield return weaponDelayShots;
            canShoot = true;
        }

        private void ApplyMuzzleEffect()
        {
            muzzle.Play();
        }

        private void ProcessRayCast()
        {
            RaycastHit hit;
            if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
            {
                //Debug.Log(hit.collider.gameObject.name);

                //VFX
                CreateImpact(hit);

                //Apply Damage
                EnemyHealth targetHealth = hit.transform.GetComponent<EnemyHealth>();
                if (targetHealth == null) { return; }
                targetHealth.TakeDamage(damage);
            }
            else
            {
                return;
            }
        }

        private void CreateImpact(RaycastHit hit)
        {
            Vector3 positionRayImpact = hit.point;
            GameObject impact = Instantiate(hitEffect, positionRayImpact, Quaternion.LookRotation(hit.normal));

            foreach (Transform child in impact.transform)
            {
                child.GetComponent<ParticleSystem>().Play();
            }

            StartCoroutine(TimeDelay(impact));

        }

        IEnumerator TimeDelay(GameObject objeto)
        {
            yield return waitImpactEffect;
            Destroy(objeto);
        }
    }

}


/*
[ALTERNATIVE] alternative way, I leave this fragment here for further study
 
        [SerializeField] Camera FPCamera;
        [SerializeField] float range = 100f;
        [SerializeField] float hitDamage = 10f;
        [SerializeField] ParticleSystem muzzleFlash;
        [SerializeField] GameObject hitEffect;
        [SerializeField] Ammo ammoSlot;
        [SerializeField] float firingRate = 0.2f;
        [SerializeField] float nextFire = 0.0f;
     
        void Update()
        {
            if(Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + firingRate;
                Shoot();
            }
        }

*/
