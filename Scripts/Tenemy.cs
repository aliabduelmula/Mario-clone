using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tenemy : MonoBehaviour
{
    public GameObject player;
    public MovePlayer playerScript;
    //public Vector3 dir;
    public int speed = 4;
    private bool moveRight;
    public float pos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<MovePlayer>();
        moveRight = false;
        pos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //dir = (player.transform.position - transform.position).normalized;
        //transform.position += (dir * speed * Time.deltaTime);
        if (transform.position.x >= pos + 5)
        {
            moveRight = false;
            pos = transform.position.x;
        }
        if (transform.position.x <= pos - 5)
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.hp -= 15;
        }

    }
}
