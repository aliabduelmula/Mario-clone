using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    private GameObject enemy;
    private Rigidbody rb;
    public Game game;
    public int bump = 200;
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
            game.enemies++;
            game.enemy.text = "Enemies: " + game.enemies;
            Destroy(enemy);
        }

    }
}
