using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penemy : MonoBehaviour
{
    public bool rise = true;
    public float speed = 1.5f;
    public float pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= pos + 5)
        {
            rise = false;
            pos = transform.position.y;
        }
        if (transform.position.y <= pos - 5)
        {
            rise = true;
            pos = transform.position.y;
        }
        if (rise)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            transform.localScale += Vector3.up * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            transform.localScale += Vector3.down * speed * Time.deltaTime;
        }
    }
}
