using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float time, diftime;
    public Color c;
    public Benemy parentScript;
    public bool detonate = false;
    public MovePlayer player;
    // Start is called before the first frame update
    void Start()
    {
        c = gameObject.GetComponent<Renderer>().material.color;
        parentScript = gameObject.transform.parent.gameObject.GetComponent<Benemy>();
        gameObject.GetComponent<Renderer>().material.color = new Color(c.r, c.g, c.b, 0.15f);
        player = GameObject.Find("Player").GetComponent<MovePlayer>();
        time = Time.time;
        diftime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= time + 1.0f)
        {
            detonate = true;
            gameObject.GetComponent<Renderer>().material.color = new Color(c.r, c.g, c.b, 0.6f);
            
        }
        if(Time.time >= time + 2.0f)
        {
            parentScript.immune = false;
            parentScript.weak.SetActive(true);
            transform.parent.gameObject.GetComponent<Renderer>().material.color = new Color(parentScript.c.r, parentScript.c.g, parentScript.c.b, 1.0f);
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && detonate)
        {
            player.hp -= 30;
            player.rb.AddForce(transform.up * 200);
            parentScript.immune = false;
            parentScript.weak.SetActive(true);
            transform.parent.gameObject.GetComponent<Renderer>().material.color = new Color(parentScript.c.r, parentScript.c.g, parentScript.c.b, 1.0f);
            Destroy(gameObject);
        }
    }
}
