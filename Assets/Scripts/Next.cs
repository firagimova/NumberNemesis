using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //if the current scene's indext is 3, load the next scene
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            //load the next scene after 5 seconds
            Invoke("LoadNextScene", 5f);
            
        }
        else
        {
            //otherwise, load the next scene
            Invoke("MainMenu", 16f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadNextScene()
    {
        //load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
