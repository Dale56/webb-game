using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwKnife : MonoBehaviour
{
    [SerializeField] public GameObject knife;
    [SerializeField] public GameObject player;
    [SerializeField] public float force;
    [SerializeField] public float torque;
    [SerializeField] public int maxSpin;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse2)){
            var newInstance = Instantiate(knife, transform.position+(transform.forward) + new Vector3(0,0.45f,0), (transform.rotation));
            Rigidbody instance = newInstance.GetComponent<Rigidbody>();
            instance.maxAngularVelocity = maxSpin;
            instance.AddRelativeForce(Vector3.forward * force);
            instance.AddRelativeTorque(torque, 0, 0);
        }
    }
}
