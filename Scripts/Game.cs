using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text koins, enemy;
    public int coins = 0;
    public int enemies = 0;
    // Start is called before the first frame update
    void Start()
    {
        koins = transform.Find("Coins").GetComponent<Text>();
        enemy = transform.Find("cenemy").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
