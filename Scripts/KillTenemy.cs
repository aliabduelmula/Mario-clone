using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTenemy : MonoBehaviour
{
    [SerializeField] public GameObject miniPrefab;
    private GameObject enemy;
    private Rigidbody rb;
    public Game game;
    public int bump = 150;
  
    // Start is called before the first frame update
    void Start()
    {
        enemy = transform.parent.gameObject;
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();
        game = GameObject.Find("Canvas").GetComponent<Game>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //game.coins++;
        //game.koins.text = "Coins: " + game.coins;
        if (other.gameObject.tag == "Player")
        {
            rb.AddForce(transform.up * bump);
            GameObject mini1 = Instantiate(miniPrefab);
            GameObject mini2 = Instantiate(miniPrefab);
            mini1.transform.position = new Vector3(transform.position.x, 1, transform.position.z);
            mini2.transform.position = new Vector3(transform.position.x+2, 1, transform.position.z);
            
            Destroy(enemy);
        }

    }
}
