using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bar : MonoBehaviour
{
    public GameObject grid;

    public void clicktoggle()
    {
        for (int i = 0; i < grid.transform.childCount; i++)
        {
            GameObject item = grid.transform.GetChild(i).gameObject;
            Destroy(item);
        }
    }

    public void clear()
    {
        SceneManager.LoadScene("mahjong");
        next.nextstep = 0;
    }
}
