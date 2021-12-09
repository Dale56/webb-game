using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttackDamage : MonoBehaviour
{
    [SerializeField] public Transform sphereHolder;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack() 
    {
        Collider[] colliders = Physics.OverlapSphere(sphereHolder.position, 1.5f);
            foreach(Collider c in colliders)
            {
                if(c.GetComponent<EnemyAI>()) {
                    c.GetComponent<EnemyAI>().TakeDamage(25);
                }
            }
    }
}
