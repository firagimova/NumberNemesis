using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene(0) after 18 seconds
        Invoke("BackToMainMenu", 17f);
    }

    // Update is called once per frame
    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
