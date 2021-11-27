using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] public GameObject bulletPrefab;
    [SerializeField] public GameObject menPrefab;
    [SerializeField] public GameObject benPrefab;
    [SerializeField] public GameObject tenPrefab;
    [SerializeField] public GameObject frenPrefab;
    public float time, spawntime;
    public Vector3 middir, topdir, botdir;
    public MovePlayer playerScript;
    public GameObject player;
    private bool down = false;
    public float speed = 2;
    public int pos;
    // Start is called before the first frame update
    void Start()
    {
        middir = new Vector3(-1, 0, 0);
        topdir = new Vector3(-1, 1, 0);
        botdir = new Vector3(-1, -1, 0);
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<MovePlayer>();
        time = Time.time;
        spawntime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= time + 1.0f)
        {
            GameObject topbullet = Instantiate(bulletPrefab);
            topbullet.transform.position = transform.position;
            topbullet.GetComponent<Bullet>().setup(topdir);
            GameObject midbullet = Instantiate(bulletPrefab);
            midbullet.transform.position = transform.position;
            midbullet.GetComponent<Bullet>().setup(middir);
            GameObject botbullet = Instantiate(bulletPrefab);
            botbullet.transform.position = transform.position;
            botbullet.GetComponent<Bullet>().setup(botdir);
            time = Time.time;
        }
        if (transform.position.y >= 9)
        {
            down = true;
            
        }
        if (transform.position.y <= 0.5)
        {
           down = false;
            
        }
        if (down)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Time.time >= spawntime + 7.5f)
        {
            pos = UnityEngine.Random.Range(1, 4);
            if (pos == 1)
            {
                GameObject enemy = Instantiate(menPrefab);
                enemy.transform.position = transform.position + Vector3.down;
            }
            else if (pos == 2)
            {
                GameObject enemy = Instantiate(benPrefab);
                enemy.transform.position = transform.position + Vector3.down;
            }
            else if (pos == 3)
            {
                GameObject enemy = Instantiate(tenPrefab);
                enemy.transform.position = transform.position + Vector3.down;
            }
            else if(pos == 4)
            {
                GameObject enemy = Instantiate(frenPrefab);
                enemy.transform.position = transform.position + Vector3.down;
            }
            
            spawntime = Time.time;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.hp -= 30;
        }

    }
}
