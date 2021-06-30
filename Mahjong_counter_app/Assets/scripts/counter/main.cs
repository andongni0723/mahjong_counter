using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    //RectTransform rt;
    [Header("角色物件")]
    //one light
    public Text z1;
    public Text z2;
    public Text z3;
    public Text z4;
    //name
    public InputField n1; 
    public InputField n2;
    public InputField n3;
    public InputField n4;
    //one
    public Button o1;
    public Button o2;
    public Button o3;
    public Button o4;
    //add
    public Button a1;
    public Button a2;
    public Button a3;
    public Button a4;
    //less
    public Button l1;
    public Button l2;
    public Button l3;
    public Button l4;
    //text
    public Text p1t;
    public Text p2t;
    public Text p3t;   
    public Text p4t;
    [Header("物件")]
    public Text dice;
    public Text wing;
    public Text tozhuang;
    public Text steptext;
    public Text dt;
    //s0
    public GameObject nn;
    public Text money;
    public GameObject mc;
    public InputField dit;
    public InputField tait;
    //s1
    public GameObject okpanel;
    public bool ok;
    //s2
    public Button nextbutton;
    //s3
    public GameObject counter;
    public int andorless = -1;
    public int player;

    public Text counternumtext;
    public int counternum;
    [Header("變數")]
    public int dicenum;
    public int step;
    public int di;
    public int tai;
    //zhuang
    public int nowzhuang;
    public int lastzhuang;
    public int againzhuang;

    void Start()
    {
        //rt = GetComponent<RectTransform>();

        if(step == 0)
        {
            steptext.text = "選擇初始值";
            nn.SetActive(true);
        }
    }

    
    void Update()
    {
        
    }

    public void okangle(float angle)
    {
        okpanel.SetActive(true);
        okpanel.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, angle);
    }

    public void counterangle(float angle)
    {
        counter.SetActive(true);
        counter.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, angle);
    }
    //gameobject angle to the playernum
    public int angletoplayer(Vector3 angle)
    {
        int ri = 0;

        if (angle.z == 0)
        {
            ri = 1;
        }
        else if(angle.z == 90)
        {
            ri = 2;
        }
        else if(angle.z == 180)
        {
            ri = 3;
        }
        else if(angle.z == 270)
        {
            ri = 4;
        }

        return ri;
    }

    //one light to onpe
    public void lightopen()
    {
        //all light off
        z1.gameObject.SetActive(false);
        z2.gameObject.SetActive(false);
        z3.gameObject.SetActive(false);
        z4.gameObject.SetActive(false);

        if (nowzhuang == 1)
        {
            z1.gameObject.SetActive(true);
        }
        else if (nowzhuang == 2)
        {
            z2.gameObject.SetActive(true);

        }
        else if (nowzhuang == 3)
        {
            z3.gameObject.SetActive(true);
        }
        else if (nowzhuang == 4)
        {
            z4.gameObject.SetActive(true);
        }
    }

    //the game is to around
    public string nextwing(Text wingtext)
    {
        string wt = null;

        if (wingtext.text == "東")
        {
            wt = "南";
        }
        else if (wingtext.text == "南")
        {
            wt = "西";
        }
        else if (wingtext.text == "西")
        {
            wt = "北";
        }
        else if (wingtext.text == "北")
        {
            wt = "e";
        }

        return wt;
    }

    public void s0ok()
    {
        p1t.text = money.text;
        p2t.text = money.text;
        p3t.text = money.text;
        p4t.text = money.text;

        di = int.Parse(dit.text);
        tai = int.Parse(tait.text);

        dt.text = dit.text + "底," + tait.text + "台";

        step = 1;
    }

    public void s1()
    {
        steptext.text = "選擇莊家";

        //name input opem
        n1.interactable = true;
        n2.interactable = true;
        n3.interactable = true;
        n4.interactable = true;

        if (nowzhuang == 0)
        {
            o1.interactable = true;
            o2.interactable = true;
            o3.interactable = true;
            o4.interactable = true;
        }
        else if(nowzhuang == 1)
        {
            o1.interactable = true;
            o2.interactable = true;
        }
        else if(nowzhuang == 2)
        {
            o2.interactable = true;
            o3.interactable = true;
        }
        else if (nowzhuang == 3)
        {
            o3.interactable = true;
            o4.interactable = true;
        }
        else if (nowzhuang == 4)
        {
            o4.interactable = true;
            o1.interactable = true;
        }
    }
    public void s1ok()
    {
        
        int tz;
        string tzs;
        //dice start
        dicenum = Random.Range(1, 19);
        dice.text = dicenum.ToString();

        lastzhuang = nowzhuang;

        nowzhuang = angletoplayer(okpanel.GetComponent<RectTransform>().localEulerAngles);

        if (againzhuang == 0)
        {
            againzhuang = angletoplayer(okpanel.GetComponent<RectTransform>().localEulerAngles);
        }
        else
        {
            

            if (nowzhuang == lastzhuang)
            {
                tz = int.Parse(tozhuang.text);
                tz += 1;
                tzs = tz.ToString();
                tozhuang.text = tzs;
            }
            else
            {
                tozhuang.text = "0";                
            }

            if(againzhuang == nowzhuang && lastzhuang != nowzhuang)
            {
                wing.text = nextwing(wing);

                if(wing.text == "e")
                {
                    step = 10;
                }
            }
        }
        lightopen();
        
        okpanel.SetActive(false);

        step = 2;
    }

    public void s2()
    {
        //all one button interactable to false 22 154 0 255 ,255 0 0 255
        o1.interactable = false;
        o2.interactable = false;
        o3.interactable = false;
        o4.interactable = false;

        nextbutton.interactable = true;
        steptext.text = "遊戲進行中";
        steptext.color = new Color32(22, 154, 0, 255);
    }

    public void nextbuttonsteps()
    {
        if(step == 2)
        {
            step = 3;
            //snextbutton.interactable = false;

            s3();
        }
        else if(step == 3)
        {
            s3alon(1);
            s1();

            nextbutton.interactable = false;
        }
    }

    public void s3()
    {
        steptext.text = "計算籌碼加減";
        steptext.color = new Color32(22, 154, 0, 255);

        s3alon(0);
    }

    public void s3alon(int boolnum) 
    {
        if(boolnum == 0)
        {
            //add
            a1.interactable = true;
            a2.interactable = true;
            a3.interactable = true;
            a4.interactable = true;
            //less
            l1.interactable = true;
            l2.interactable = true;
            l3.interactable = true;
            l4.interactable = true;
        }
        else if(boolnum == 1)
        {
            //add
            a1.interactable = false;
            a2.interactable = false;
            a3.interactable = false;
            a4.interactable = false;
            //less
            l1.interactable = false;
            l2.interactable = false;
            l3.interactable = false;
            l4.interactable = false;
        }
    }

    public void s3buttonuse(int andorless2)
    {
        s3alon(1);
        counternumtext.text = "0";
        counternum = 0;
        counter.SetActive(true);

        player = angletoplayer(counter.GetComponent<RectTransform>().localEulerAngles);

        andorless = andorless2;
    }

    //and or less player money
    public void playermoney()
    {
        

        if (andorless == 0)
        {
            
            if (player == 1)
            {
                p1t.text = (int.Parse(p1t.text) + (counternum * tai + di)).ToString();
            }
            else if (player == 2)
            {
                p2t.text = (int.Parse(p2t.text) + (counternum * tai + di)).ToString();

            }
            else if (player == 3)
            {
                p3t.text = (int.Parse(p3t.text) + (counternum * tai + di)).ToString();
            }
            else if (player == 4)
            {
                p4t.text = (int.Parse(p4t.text) + (counternum * tai + di)).ToString();
            }
        }
        else if(andorless == 1)
        {
            

            if (player == 1)
            {
                p1t.text = (int.Parse(p1t.text) - (counternum * tai + di)).ToString();
            }
            else if (player == 2)
            {
                p2t.text = (int.Parse(p2t.text) - (counternum * tai + di)).ToString();

            }
            else if (player == 3)
            {
                p3t.text = (int.Parse(p3t.text) - (counternum * tai + di)).ToString();
            }
            else if (player == 4)
            {
                p4t.text = (int.Parse(p4t.text) - (counternum * tai + di) ).ToString();
            }
        }
        
    }

    public void inputnumber(string num)
    {
        if(counternumtext.text == "0")
        {
            counternumtext.text = "";
        }
        counternumtext.text += num;
        counternum = int.Parse(counternumtext.text);
    }

    public void s3ok()
    {
        player = angletoplayer(counter.GetComponent<RectTransform>().localEulerAngles);
        playermoney();
        s3alon(0);

        counternumtext.text = "0";
        counternum = 0;

        counter.SetActive(false);
        nextbutton.interactable = true;
        andorless = -1;
    }
}
