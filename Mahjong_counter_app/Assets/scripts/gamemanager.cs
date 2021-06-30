using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public void scenenext(string snenename)
    {
        SceneManager.LoadScene(snenename);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void redo()
    {
        PlayerPrefs.DeleteAll();
    }

    public void google()
    {
        Application.OpenURL("https://sites.google.com/view/andongni");
    }
}
