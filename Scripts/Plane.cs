using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public MovePlayer player;
    public Transform playerpos, midpt;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<MovePlayer>();
        playerpos = GameObject.Find("Player").transform;
        midpt = gameObject.transform.GetChild(0).gameObject.transform;
    }
    void Update()
    {
        distance = playerpos.position.x - midpt.position.x;
        //print(distance);
        if(distance >= 25)
        {
            Destroy(gameObject);
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.jump = 2;
            
        }
    }
}
