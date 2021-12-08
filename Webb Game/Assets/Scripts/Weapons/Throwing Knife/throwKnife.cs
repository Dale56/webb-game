using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwKnife : MonoBehaviour
{
    [SerializeField] public GameObject knifeParent;
    [SerializeField] public GameObject knifeTrash;
    [SerializeField] public GameObject knife;
    [SerializeField] public GameObject player;
    [SerializeField] public float force;
    [SerializeField] public float torque;
    [SerializeField] public int maxSpin;
    [SerializeField] public double cooldown;
    public bool knifeSpawned;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // if(cooldown > 0)
        // {
        //     cooldown -= Time.deltaTime;
        // } else if(cooldown<=0 && knifeSpawned == false) {
        //     cooldown = 0;
        //     var newInstance = Instantiate(knife, transform.position, (transform.rotation));
        //     newInstance.transform.SetParent(knifeParent.transform);
        //     knifeSpawned = true;

        //     if(Input.GetKeyDown(KeyCode.Mouse2))
        // {   
        //     Rigidbody knifeRigidbody = newInstance.AddComponent<Rigidbody>();
        //     knifeRigidbody.maxAngularVelocity = maxSpin;
        //     knifeRigidbody.AddRelativeForce(Vector3.forward * force);
        //     knifeRigidbody.AddRelativeTorque(torque, 0, 0);
        //     newInstance.transform.SetParent(knifeTrash.transform);
        //     cooldown += 1.5;
        //     knifeSpawned = false;
        // }
        // } else if(cooldown < 0){
        //     cooldown = 0;
        // }
        
        if(Input.GetKeyDown(KeyCode.Mouse2))
        {   
            var newInstance = Instantiate(knife, transform.position, (transform.rotation));
            newInstance.transform.SetParent(knifeParent.transform);
            Rigidbody knifeRigidbody = newInstance.AddComponent<Rigidbody>();
            knifeRigidbody.maxAngularVelocity = maxSpin;
            knifeRigidbody.AddRelativeForce(Vector3.forward * force);
            knifeRigidbody.AddRelativeTorque(torque, 0, 0);
            newInstance.transform.SetParent(knifeTrash.transform);
            cooldown += 1.5;
            knifeSpawned = false;
        }
    }
}
