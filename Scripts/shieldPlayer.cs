using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldPlayer : MonoBehaviour
{
    public GameObject shield; 
    public bool activeShield;
    

    // Start is called before the first frame update
     void Start()
    {
        activeShield = false; 
        shield.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        //activeShield = true;
        //shield.SetActive(true); 
    }

    
   
}
