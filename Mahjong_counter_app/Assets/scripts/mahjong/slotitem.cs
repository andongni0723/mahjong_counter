using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotitem : MonoBehaviour
{
    public static slotitem instance;
    public void Awake()
    {
        instance = this;
    }

    public string mahkind;
    public string mahnum;
}
