using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class next : MonoBehaviour
{
    [Header("勾選器")]
    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;
    public GameObject t5;

    public static int nextstep = 0;
    public GameObject obj;
    public static GameObject enter;

    private void Start()
    {
        enter = GameObject.Find("enter");
    }

    public void nextsteps()
    {
        nextstep = 1;
        obj.GetComponent<Button>().interactable = false;

        //toogle的啟用設為否
        t1.GetComponent<Toggle>().interactable = false;
        t2.GetComponent<Toggle>().interactable = false;
        t3.GetComponent<Toggle>().interactable = false;
        t4.GetComponent<Toggle>().interactable = false;
        t5.GetComponent<Toggle>().interactable = false;
    }

    public void enterclick()
    {
        nextstep = 3;
    }
}
