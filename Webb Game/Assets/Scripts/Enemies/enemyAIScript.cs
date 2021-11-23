using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAIScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float attackRange;
    public bool playerInAttackRange;
    public float health;

    private void Awake() {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    private void ChasePlayer() {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer() {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked) {
            /// Attack Code Here

            ///
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    // Update is called once per frame
    void Update() {
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInAttackRange) {
            ChasePlayer();
        }
        if (playerInAttackRange) AttackPlayer();
    }

    private void ResetAttack() {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if (health<=0) {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }
    private void DestroyEnemy() {
        Destroy(gameObject);
    }

}
