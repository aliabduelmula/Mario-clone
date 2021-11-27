using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public Game game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("Canvas").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(30 * Time.deltaTime, 15 * Time.deltaTime, 45 * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            game.coins++;
            game.koins.text = "Coins: " + game.coins;
            Destroy(gameObject);
        }

    }
}
