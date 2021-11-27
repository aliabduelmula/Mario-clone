 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    public int speed = 7;
    public int jumpforce = 400;
    public Rigidbody rb;
    public int jump = 2;
    private GameObject camera;
    public int hp;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        camera = GameObject.Find("Main Camera");
        camera.transform.position = new Vector3(2, 1,-20);
        hp = 100;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            //rb.AddForce(transform.forward * speed);
        }*/
        if (Input.GetKey(KeyCode.A) && transform.position.x > camera.transform.position.x - 14)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //camera.transform.parent = null;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            /*if (transform.position.x >= camera.transform.position.x-2)
            {
                //camera.transform.Translate(Vector3.right * speed * Time.deltaTime);
                camera.transform.parent = gameObject.transform;
                camera.transform.position = new Vector3(gameObject.transform.position.x+2, camera.transform.position.y, camera.transform.position.z);
            }*/
            //camera.transform.parent = gameObject.transform;
            //camera.transform.position = new Vector3(gameObject.transform.position.x + 2, 1, -20);
        }
        if (Input.GetKeyDown(KeyCode.Space) && jump > 0)
        {
            jump--;
            rb.AddForce(transform.up * jumpforce);
            
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            speed = 12;
        }
        else
        {
            speed = 7;
        }
        if(hp <= 0)
        {
            SceneManager.LoadScene("Menu");
        }

    }

}
