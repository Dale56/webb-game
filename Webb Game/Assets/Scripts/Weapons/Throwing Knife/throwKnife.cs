using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwKnife : MonoBehaviour
{
    [SerializeField] public GameObject knife;
    [SerializeField] public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse2)){
            Instantiate(knife, transform.position+(transform.forward * 2), transform.rotation);
        }
    }
}
