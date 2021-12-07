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
    [SerializeField] public float xoffset;
    [SerializeField] public float yoffset;
    [SerializeField] public float zoffset;
    [SerializeField] public double cooldown;


    void Start()
    {
        // SpawnKnife();
    }

    // Update is called once per frame
    void Update()
    {
        ThrowKnife();
        // if(cooldown > 0)
        // {
        //     cooldown -= Time.deltaTime;
        // } else if(cooldown ) {
        //     cooldown = -0.01;
        //     var newInstance = Instantiate(knife, transform.position, (transform.rotation));
        //     newInstance.transform.SetParent(knifeParent.transform);
        // }
    }
    public void ThrowKnife()
    {
        if(cooldown<1.5 && Input.GetKeyDown(KeyCode.Mouse2))
        {
            var newInstance = Instantiate(knife, transform.position, (transform.rotation));
            newInstance.transform.SetParent(knifeParent.transform);
            Rigidbody knifeRigidbody = newInstance.AddComponent<Rigidbody>();
            knifeRigidbody.maxAngularVelocity = maxSpin;
            knifeRigidbody.AddRelativeForce(Vector3.forward * force);
            knifeRigidbody.AddRelativeTorque(torque, 0, 0);
            newInstance.transform.SetParent(knifeTrash.transform);
            // cooldown += 1.5;
        }
    }
    // public void SpawnKnife()
    // {
    //     var newInstance = Instantiate(knife, transform.position, (transform.rotation));
    //     newInstance.transform.SetParent(knifeParent.transform);
    // }
}
