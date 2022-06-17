using Game.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Combat
{
    public class EnemyIA : MonoBehaviour
    {
        [SerializeField] float chaseRange = 5f;
        [SerializeField] float speedTurn = 1.5f;

        NavMeshAgent navMeshAgent;
        Animator animatorControl;
        Transform target;

        float distanceToTarget = Mathf.Infinity;
        bool isProvoked = false;


        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            animatorControl = GetComponent<Animator>();
            target = FindObjectOfType<PlayerHealth>().transform;
        }

        void Update()
        {
            distanceToTarget = Vector3.Distance(target.position, transform.position);

            if (isProvoked)
            {
                EngageTarget();
            }
            else if (distanceToTarget <= chaseRange)
            {
                isProvoked = true;
            }
        }

        private void EngageTarget()
        {
            FaceTarget();

            if (distanceToTarget >= navMeshAgent.stoppingDistance)
            {
                ChaseTarget();
            }
            if (distanceToTarget <= navMeshAgent.stoppingDistance)
            {
                AttackTarget();
            }


        }

        public void OnDamageTaken()
        {
            isProvoked = true;
        }

        private void ChaseTarget()
        {
            animatorControl.SetBool("isAttacking", false);
            animatorControl.SetTrigger("isMoving");
            navMeshAgent.SetDestination(target.position);
        }

        private void AttackTarget()
        {
            animatorControl.SetBool("isAttacking", true);
        }


        private void FaceTarget()
        {
            Vector3 distance = (target.position - transform.position).normalized;
            Quaternion rotToPosition = Quaternion.LookRotation(new Vector3(distance.x, 0, distance.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, rotToPosition, Time.deltaTime * speedTurn);

        }

        public void Shutdown()
        {
            navMeshAgent.enabled = false;
            this.enabled = false;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseRange);
        }
    }
}