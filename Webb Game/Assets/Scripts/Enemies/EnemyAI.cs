using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public double cooldownStatic;
    public double cooldown = 0;
    public Transform movePositionTransform;
    [SerializeField] private double attackRange;
    private NavMeshAgent navMeshAgent;
    [SerializeField] public GameObject weapon;
    private GameObject player;
    [SerializeField] public int health;
    [SerializeField] public Transform sphereHolder;
    [SerializeField] public int damage;
    public int score = 0;
    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = weapon.GetComponent<Animator>();
        player = GameObject.Find("Player");
        movePositionTransform = player.transform;
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
        Collider[] colliders = Physics.OverlapSphere(sphereHolder.position, 1.5f);
            foreach(Collider c in colliders)
            {
                if(c.GetComponent<DamageHandler>()) {
                    c.GetComponent<DamageHandler>().TakeDamage(damage);
                }
            } 
        if(cooldown > 0) {
            cooldown -= Time.deltaTime;
        } else if(cooldown < 0) {
            cooldown = 0;
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;

        if(health <= 0) {
            Destroy(this.gameObject);
            score = score + 1;
            Debug.Log(score);
        }
    }
}
