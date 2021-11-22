using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] float sprintMultiplier = 1.5f;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        float realSpeed = speed;
        if(Input.GetKey(KeyCode.LeftShift)) {
            realSpeed *= sprintMultiplier;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 moveBy = transform.right * x + transform.forward * z;
        rb.MovePosition(transform.position + moveBy.normalized * realSpeed * Time.deltaTime);   
    }
}
