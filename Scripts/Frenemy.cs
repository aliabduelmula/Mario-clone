using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frenemy : MonoBehaviour
{
    [SerializeField] public GameObject platPrefab;
    public MovePlayer playerScript;
    public GameObject player;
    private bool moveRight, spawn;
    public int speed = 3;
    public float pos;
    public float time, endtime;
    GameObject plat;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<MovePlayer>();
        moveRight = true;
        spawn = false;
        pos = transform.position.x;
        time = Time.time;
        endtime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= pos + 10)
        {
            moveRight = false;
            pos = transform.position.x;
        }
        if (transform.position.x <= pos - 10)
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
        /*if (Time.time >= time + 3.0f && spawn == false)
        {
            plat = Instantiate(platPrefab);
            plat.transform.parent = gameObject.transform;
            plat.transform.position = new Vector3(transform.position.x,2,0);
            spawn = true;
            time = Time.time;
            print("spwan");
        }
        if(Time.time >= time + 3.0f && spawn)
        {
            Destroy(plat);
            spawn = false;
            print("destroy");
            time = Time.time;
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.hp -= 20;
        }

    }
}
