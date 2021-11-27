using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menemy : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    public float time;
    public Vector3 spawnpos = new Vector3(0, 0, 0);
    public GameObject player;
    public Vector3 dir;
    public MovePlayer playerScript;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= time + 3.0f)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            dir = (player.transform.position - transform.position).normalized;
            bullet.GetComponent<Bullet>().setup(dir);
            //print(dir);
            time = Time.time;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.hp -= 10;
        }

    }
}
