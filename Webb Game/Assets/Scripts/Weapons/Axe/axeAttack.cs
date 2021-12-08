using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeAttack : MonoBehaviour
{
    Animator animator;
    double cooldown = 0;
    [SerializeField] public Transform sphereHolder;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && cooldown <= 0) {
            animator.SetTrigger("Attack");
            cooldown += 2;

            Collider[] colliders = Physics.OverlapSphere(sphereHolder.position, 1.5f);
            foreach(Collider c in colliders)
            {
                if(c.GetComponent<EnemyAI>()) {
                    c.GetComponent<EnemyAI>().TakeDamage(25);
                }
            }
        } 
        if(cooldown < 0) {
            cooldown = 0;
        } else {
            cooldown -= Time.deltaTime;
        }

        
    }
}
