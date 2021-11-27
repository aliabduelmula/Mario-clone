using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZone : MonoBehaviour
{
    public MovePlayer player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<MovePlayer>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.hp -= 100;
        }
    }
}
