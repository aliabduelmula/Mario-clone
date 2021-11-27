using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveYPlat : MonoBehaviour
{
    private bool moveup;
    public int speed = 3;
    public float pos;
    public MovePlayer player;
    public Transform playerpos, midpt;
    public float distance;
    void Start()
    {
        moveup = true;
        pos = transform.position.y;
        player = GameObject.Find("Player").GetComponent<MovePlayer>();
        playerpos = GameObject.Find("Player").transform;
        midpt = gameObject.transform.GetChild(0).gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y >= pos + 15)
        {
            moveup = false;
            pos = transform.position.y;
        }
        if (transform.position.y <= pos - 15)
        {
            moveup = true;
            pos = transform.position.y;
        }
        if (moveup)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        distance = playerpos.position.x - midpt.position.x;
        //print(distance);
        if (distance >= 25)
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
    /*private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }*/
}
