using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveXPlat : MonoBehaviour
{
    private bool moveRight;
    public int speed = 5;
    public float pos;
    public MovePlayer player;
    public Transform playerpos, midpt;
    public float distance;
    void Start()
    {
        moveRight = true;
        pos = transform.position.x;
        player = GameObject.Find("Player").GetComponent<MovePlayer>();
        playerpos = GameObject.Find("Player").transform;
        midpt = gameObject.transform.GetChild(0).gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x >= pos + 15)
        {
            moveRight = false;
            pos = transform.position.x;
        }
        if (transform.position.x <= pos - 15)
        {
            moveRight = true;
            pos = transform.position.x;
        }
        if (moveRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
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
        other.transform.parent = transform;
        if (other.gameObject.tag == "Player")
        {
            player.jump = 2;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent = null;
    }
}
