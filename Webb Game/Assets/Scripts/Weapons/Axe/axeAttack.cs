using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeAttack : MonoBehaviour
{
    Animator animator;
    double cooldown = 0;
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
        } 
        if(cooldown < 0) {
            cooldown = 0;
        } else {
            cooldown -= Time.deltaTime;
        }

        
    }
}
