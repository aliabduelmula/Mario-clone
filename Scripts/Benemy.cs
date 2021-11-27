using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benemy : MonoBehaviour
{
    [SerializeField] public GameObject explposionPrefab;
    public float time, difftime;
    public GameObject player;
    public Vector3 offset = new Vector3(-2, 0, 0);
    public bool immune = false;
    public Color c,e;
    public GameObject weak, explosion;
    public MovePlayer playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        c = gameObject.GetComponent<Renderer>().material.color;
        weak = gameObject.transform.GetChild(0).gameObject;
        time = Time.time;
        playerScript = player.GetComponent<MovePlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time >= time + 5.0f && !immune)
        {
            transform.position = player.transform.position - offset;
            immune = true;
            gameObject.GetComponent<Renderer>().material.color = new Color(c.r, c.g, c.b, 0.5f);
            weak.SetActive(false);
            
            explosion = Instantiate(explposionPrefab);
            explosion.transform.parent = gameObject.transform;
            explosion.transform.position = transform.position;
            time = Time.time;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerScript.hp -= 20;
        }

    }

}
