using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupShieldPowerup : MonoBehaviour
{
    public GameObject player;
    public float duration = 5f;
    public float time;
    private void Start()
    {
        player = GameObject.Find("Player");
        time = Time.time;

    }
    void Update()
    {
        if (Time.time >= time + 30.0f)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           


          StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider Player)
    {
        Debug.Log("Shield power up picked up");

        GetComponent<MeshRenderer>().enabled = false;
        
        Player.GetComponent<shieldPlayer>().activeShield = true;
        Player.GetComponent<shieldPlayer>().shield.SetActive(true);
        
        yield return new WaitForSeconds(duration);
        Player.GetComponent<shieldPlayer>().activeShield = false;
        Player.GetComponent<shieldPlayer>().shield.SetActive(false);

      
 
        Destroy(gameObject); 


    }



     
}
