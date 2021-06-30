using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class save2 : MonoBehaviour
{
    main2 main2;

    public int span = 10;
    public float timer;

    public bool isundo = false;

    void Start()
    {
        main2 = GameObject.Find("gamemanager").GetComponent<main2>();
    }
    private void Awake()
    {
        //loaddata();   
    }


    void Update()
    {
        timer += Time.deltaTime;
        if(timer > span)
        {
            savedata();
        }
    }

    public void savedata()
    {
        PlayerPrefs.SetInt("2p1",int.Parse(main2.p1t.text));
        PlayerPrefs.SetInt("2p3", int.Parse(main2.p3t.text));
        PlayerPrefs.SetInt("2step", main2.step);
        PlayerPrefs.SetInt("dice", main2.dicenum);
        PlayerPrefs.SetInt("di", main2.di);
        PlayerPrefs.SetInt("tai", main2.tai);

        PlayerPrefs.SetInt("2nowzhuang", main2.nowzhuang);
        PlayerPrefs.SetInt("2lastzhuang", main2.lastzhuang);
        PlayerPrefs.SetInt("2againzhuang", main2.againzhuang);

        PlayerPrefs.SetString("wingt", main2.wing.text);
        PlayerPrefs.SetString("tzt", main2.tozhuang.text);

    }

    public void undo()
    {
        isundo = true;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("counter2");
        isundo = false;
    }
}
