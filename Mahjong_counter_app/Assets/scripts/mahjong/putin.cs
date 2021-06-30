using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class putin : MonoBehaviour
{
    [Header("麻將數據")]
    public GameObject mahjongbutton;
    public string kind;
    public int spritesnum = 1;
    public string num;
    public Sprite sprite;
    public int usesnum = 0;

    public GameObject donepanel;
    public GameObject grid;
    public GameObject toggle;
    public GameObject fgrid;
    //public List<GameObject> maha = mahjongcounter.instance.g1;
    GameObject slot;
    

    public GameObject prefab;
    private void Update()
    {
        if(next.nextstep == 0 || next.nextstep == 2 || usesnum >= 4) //以nextstep , usenum變數來判斷麻將按鈕要不要開啟
        {
            mahjongbutton.GetComponent<Button>().interactable = false; // no
        }
        else if(next.nextstep == 1)
        {
            mahjongbutton.GetComponent<Button>().interactable = true;  //yes
        }
        

        if (grid.transform.childCount == 3)
        {
            spritesnum++;
        }

        if(spritesnum == 6 && grid.transform.childCount == 2)
        {
            mahjongbutton.GetComponent<Button>().interactable = false;
        }

        //變數切換
        if (spritesnum == 2)
        {
            grid = GameObject.Find("Image1");
            toggle = GameObject.Find("gang2");
            fgrid = GameObject.Find("Image (14)");
            //maha = mahjongcounter.instance.g2;
        }
        else if (spritesnum == 3)
        {
            grid = GameObject.Find("Image (2)");
            toggle = GameObject.Find("gang3");
            fgrid = GameObject.Find("Image (15)");
            //maha = mahjongcounter.instance.g3;
        }
        else if (spritesnum == 4)
        {
            grid = GameObject.Find("Image (3)");
            toggle = GameObject.Find("gang4");
            fgrid = GameObject.Find("Image (16)");
            //maha = mahjongcounter.instance.g4;
        }
        else if (spritesnum == 5)
        {
            grid = GameObject.Find("Image (4)");
            toggle = GameObject.Find("gang5");
            fgrid = GameObject.Find("Image (17)");
            //maha = mahjongcounter.instance.g5;
        }
        else if (spritesnum == 6)
        {
            grid = GameObject.Find("Image (12)");
            //maha = mahjongcounter.instance.g6;
        }
    }

    public void put()
    {
        if (spritesnum == 6)
        {
            if(usesnum <= 2)
            {
                instantiates();
                instantiates();
                mahjongbutton.GetComponent<Button>().interactable = false;
                usesnum += 2;
                next.enter.GetComponent<Button>().interactable = true;
                next.nextstep = 2;
            }

        }
        else if (toggle.GetComponent<Toggle>().isOn)
        {
            if(usesnum == 0)
            {
                instantiates();
                instantiates();
                instantiates();

                usesnum = 4;
                fgrid.GetComponent<Image>().sprite = sprite;

            }
        }
        else if (!toggle.GetComponent<Toggle>().isOn || spritesnum == 6)
        {
            instantiates();
            usesnum += 1;
            
        }

        

    }

    public void instantiates()
    {
        slot = Instantiate(prefab, prefab.transform.position, Quaternion.identity);
        slot.gameObject.transform.SetParent(grid.transform);
        slot.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        slot.GetComponent<Image>().sprite = sprite;
        slot.GetComponent<slotitem>().mahkind = kind;
        slot.GetComponent<slotitem>().mahnum = num;

        //maha.Add(slot);
        mahjongcounter.instance.append(slot);
    }

    
}
