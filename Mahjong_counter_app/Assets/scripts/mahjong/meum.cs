using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meum : MonoBehaviour
{
    public RectTransform Rect;
    public float rextposx;
    public bool isopen;

    public void onclick()
    {
        if (!isopen)
        {
            Rect.position = new Vector3(Screen.width * rextposx, Rect.position.y, 0f);
            isopen = true;
        }
        else
        {
            Rect.position = new Vector3(Rect.position.x + Screen.width * rextposx, Rect.position.y, 0f);
            isopen = false;
        }
        
    }
}
