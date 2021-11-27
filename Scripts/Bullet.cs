using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public int speed = 10;
    public float time;
    public Vector3 dir;
    public MovePlayer player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<MovePlayer>();
        time = Time.time;
    }
    public void setup(Vector3 dir)
    {
        this.dir = dir;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
        if (Time.time >= time + 5.0f)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.hp -= 25;
            Destroy(gameObject);
        }
        
    }
}
