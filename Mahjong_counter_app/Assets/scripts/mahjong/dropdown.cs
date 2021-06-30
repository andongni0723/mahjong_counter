using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dropdown : MonoBehaviour
{
    public Text num;

    public void handleinputdata(int var)
    {
        if(var == 0)
        {
            num.text = "0";
        }
        if (var == 1)
        {
            num.text = "1";
        }
        if (var == 2)
        {
            num.text = "2";
        }
        if (var == 3)
        {
            num.text = "3";
        }
        if (var == 4)
        {
            num.text = "4";
        }
        if (var == 5)
        {
            num.text = "5";
        }
        if (var == 6)
        {
            num.text = "6";
        }
        if (var == 7)
        {
            num.text = "7";
        }
        if (var == 8)
        {
            num.text = "8";
        }
        if (var == 9)
        {
            num.text = "9";
        }
    }
}
