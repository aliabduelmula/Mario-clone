using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawn : MonoBehaviour
{
    public GameObject player;
    public float playerpos;
    [SerializeField] public GameObject platPrefab;
    [SerializeField] public GameObject platyPrefab;
    [SerializeField] public GameObject platxPrefab;
    [SerializeField] public GameObject finPrefab;
    [SerializeField] public GameObject coinPrefab;
    [SerializeField] public GameObject menPrefab;
    [SerializeField] public GameObject penPrefab;
    [SerializeField] public GameObject danPrefab;
    [SerializeField] public GameObject hpPrefab;
    [SerializeField] public GameObject shPrefab;
    public Vector3 spawnpt = new Vector3(40, 0, 0);
    public int section;
    public int platsp, dgz;
    public bool lvlfin = false;
    public GameObject plat;
    public GameObject coin1, coin2;
    public GameObject men;
    public GameObject pen;
    public GameObject dgzone;
    public GameObject pup;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerpos = player.transform.position.x;
        section = 400;
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.x >= playerpos + 15f && player.transform.position.x < section)
        {
            //print("spawn");
            //posy = UnityEngine.Random.Range(-4, 5);
            platsp = UnityEngine.Random.Range(0, 3);
            dgz = UnityEngine.Random.Range(0, 2);
            

            if (platsp == 0)
            {

                plat = Instantiate(platPrefab);
                plat.transform.position = spawnpt;
                platsp = UnityEngine.Random.Range(0, 2);
                if (platsp == 0) // menemy
                {
                    coin1 = Instantiate(coinPrefab);
                    coin1.transform.position = spawnpt + new Vector3(0, 1.5f, 0);
                    //coin1.transform.parent = plat.transform;
                    coin2 = Instantiate(coinPrefab);
                    coin2.transform.position = spawnpt - new Vector3(4,-1.5f,0);
                    //coin2.transform.parent = plat.transform;
                    men = Instantiate(menPrefab);
                    men.transform.position = spawnpt + new Vector3(4, 1.5f, 0);
                    men.transform.parent = plat.transform;
                }
                else // penemy
                {
                    coin1 = Instantiate(coinPrefab);
                    coin1.transform.position = spawnpt + new Vector3(0, 1.5f, 0);
                    //coin1.transform.parent = plat.transform;
                    coin2 = Instantiate(coinPrefab);
                    coin2.transform.position = spawnpt + new Vector3(4, 1.5f, 0);
                    //coin2.transform.parent = plat.transform;
                    pen = Instantiate(penPrefab);
                    pen.transform.position = spawnpt - new Vector3(4, -1f, 0);
                    pen.transform.parent = plat.transform;
                }
                    spawnPlat(0, 0);
            }
            else if (platsp == 1)
            {
                platsp = UnityEngine.Random.Range(0, 4);
                plat = Instantiate(platyPrefab);
                plat.transform.position = spawnpt;
                spawnPlat(0, 15);
                if (platsp == 0) //hp up
                {
                    pup = Instantiate(hpPrefab);
                    pup.transform.position = spawnpt + new Vector3(0, 1.5f, 0);
                    //pup.transform.parent = plat.transform;
                }
                else if(platsp == 1)
                {
                    pup = Instantiate(shPrefab);
                    pup.transform.position = spawnpt + new Vector3(0, 1.5f, 0);
                    // pup.transform.parent = plat.transform;
                }

            }
            else
            {
                platsp = UnityEngine.Random.Range(0, 4);
                plat = Instantiate(platxPrefab);
                plat.transform.position = spawnpt;
                spawnPlat(15, 0);
                if (platsp == 0) //hp up
                {
                    pup = Instantiate(hpPrefab);
                    //pup.transform.parent = plat.transform;
                    pup.transform.position = spawnpt + new Vector3(0, 1.5f, 0);
                }
                else if (platsp == 1)
                {
                    pup = Instantiate(shPrefab);
                    //pup.transform.parent = plat.transform;
                    pup.transform.position = spawnpt + new Vector3(0, 1.5f, 0);

                }
            }
            //plat = Instantiate(platPrefab);
            if (dgz == 0)
            {
                dgzone = Instantiate(danPrefab);
                dgzone.transform.position = spawnpt + new Vector3(0, 6, 0);
                dgzone.transform.parent = plat.transform;
            }

            spawnpt.x += 10;
            playerpos = player.transform.position.x;

        }
        else if (player.transform.position.x >= section && lvlfin == false)
        {
            plat = Instantiate(finPrefab);
            plat.transform.position = spawnpt;
            lvlfin = true;
        }
    }

    public void spawnPlat(int x, int y)
    {
        spawnpt.x += UnityEngine.Random.Range(0+x, 10+x);
        spawnpt.y += UnityEngine.Random.Range(-4, y);
    }
}
