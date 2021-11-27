using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadGame()
    {
        Text text = transform.Find("Text").GetComponent<Text>(); ;
        SceneManager.LoadScene(text.text);
    }
}
