using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class allcounterdata : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void tocounter()
    {
        if (PlayerPrefs.GetInt("step") != 0)
        {
            SceneManager.LoadScene("counter");
        }else if (PlayerPrefs.GetInt("2step") != 0)
        {
            SceneManager.LoadScene("counter2");
        }
        else
        {

        }
        
    }
}
