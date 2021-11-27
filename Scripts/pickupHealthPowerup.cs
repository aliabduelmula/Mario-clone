using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupHealthPowerup : MonoBehaviour
{
    public MovePlayer mp;
    public float time;
    void Start()
    {
        mp = GameObject.Find("Player").GetComponent<MovePlayer>();
        time = Time.time;
    }

    void Update()
    {
        if(Time.time >= time + 30.0f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            mp.hp = 100;
            Destroy(gameObject);
        }


    }

    /*void Pickup(Collider Player)
    {
        Debug.Log("health power up picked up");
        playerHealth stats = Player.GetComponent<playerHealth>();
        if(stats.health == 1)
        {
            stats.health += 2;
            Debug.Log("health reset to 3");
        }

        if (stats.health == 2)
        {
            stats.health += 1;
            Debug.Log("Health reset to 3"); 
        }
        
        

    }*/
}
