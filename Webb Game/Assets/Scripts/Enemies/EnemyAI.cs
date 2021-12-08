using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public double cooldownStatic;
    public double cooldown = 0;
    [SerializeField] private Transform movePositionTransform;
    [SerializeField] private double attackRange;
    private NavMeshAgent navMeshAgent;
    [SerializeField] public GameObject weapon;
    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = weapon.GetComponent<Animator>();
    }

    private void Update() {
        if(Vector3.Distance(movePositionTransform.position, transform.position) > attackRange) {
            navMeshAgent.destination = movePositionTransform.position;
        } else {
            navMeshAgent.destination = transform.position;
            transform.LookAt(movePositionTransform, Vector3.up);
            }

        if(cooldown <= 0 && Vector3.Distance(movePositionTransform.position, transform.position) < attackRange) {
            animator.SetTrigger("Mace Attack 1");
            cooldown = 0;
            cooldown += cooldownStatic;
        }
        if(cooldown > 0) {
            cooldown -= Time.deltaTime;
        } else if(cooldown < 0) {
            cooldown = 0;
        }
    }
}
