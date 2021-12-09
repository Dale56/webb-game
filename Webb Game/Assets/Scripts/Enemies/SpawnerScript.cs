using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] public GameObject enemy;
    public float cooldown = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cooldown>0){
            cooldown-=Time.deltaTime;
        } else if(cooldown<=0) {
            var newInstance = Instantiate(enemy, transform.position, (transform.rotation));
            cooldown = 5;
        }
    }
}
