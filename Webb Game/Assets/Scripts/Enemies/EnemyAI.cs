using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;
    private void Awake() {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        Debug.Log(Vector3.Distance(movePositionTransform.position, transform.position));
        if(Vector3.Distance(movePositionTransform.position, transform.position) > 3) {
            navMeshAgent.destination = movePositionTransform.position;
        } else {
            navMeshAgent.destination = transform.position;
        }
    }
}
