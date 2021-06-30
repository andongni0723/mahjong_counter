using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mahjongcounter : MonoBehaviour
{
    public RectTransform Rect;
    public float rectpos;

    public bool isopen;
    public bool havestr = false;

    [Header("畫布物件")]
    public Text text;
    public Text taitext;
    public Text errortext;
    public Text cheattext;
    public Image panel1;
    public Text tainum;
    public string mywing;
    public string allwing;

    [Header("台數物件")]
    public Toggle gang1;
    public Toggle gang2;
    public Toggle gang3;
    public Toggle gang4;
    public Toggle gang5;
    public Toggle an1;
    public Toggle an2;
    public Toggle an3;
    public Toggle an4;
    public Toggle an5;
    public Dropdown dropdown;
    public Dropdown mydropdown;
    public Dropdown alldropdown;
    public Toggle t1;  //獨聽
    public Toggle t2;  //花台
    public Toggle t3;  //自摸
    public Toggle t6;  //槓上開花
    public Toggle t7;  //海底撈月
    public Toggle t8;  //天胡
    public Toggle t9;  //天聽
    public Toggle t10; //地胡
    public Toggle t11; //人胡
    public Toggle t12; //花槓 
    public Toggle t13; //莊家
    public Toggle t14; //搶槓
    public Toggle t15; //河底撈魚
    public Toggle t16; //有花
    public Toggle t17; //地聽

    public int sumtai = 0;
    public int sumone = 0;


    //單例化
    public static mahjongcounter instance;
    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> g1 = new List<GameObject>();

    //  0 是碰,1 是吃, 2 是槓, 3 是錯誤 
    [Header("狀態")]
    public int g1s;
    public int g2s;
    public int g3s;
    public int g4s;
    public int g5s;

    private void Update()
    {
        if (mydropdown.value == 0)
        {
            mywing = "e";
        }
        else if (mydropdown.value == 1)
        {
            mywing = "s";
        }
        else if (mydropdown.value == 2)
        {
            mywing = "w";
        }
        else if (mydropdown.value == 3)
        {
            mywing = "n";
        }

        if (alldropdown.value == 0)
        {
            allwing = "e";
        }
        else if (alldropdown.value == 1)
        {
            allwing = "s";
        }
        else if (alldropdown.value == 2)
        {
            allwing = "w";
        }
        else if (mydropdown.value == 3)
        {
            allwing = "n";
        }
    }

    public void append(GameObject item)
    {
        g1.Add(item);
    }


    public void counter()
    {
        taitext.text = "";
        errortext.text = "";
        sumtai = 0;
        sumone = 0;       

        g1s = addc(gang1,an1, 0, 1, 2, g1s,1);
        g2s = addc(gang2,an2, 3, 4, 5, g2s,2);
        g3s = addc(gang3,an3, 6, 7, 8, g3s,3);
        g4s = addc(gang4,an4, 9, 10, 11, g4s,4);
        g5s = addc(gang5,an5, 12, 13, 14, g5s,5);

        twoerrorif(15);

        othertai();

        tainum.text = sumtai.ToString();

        if (errortext.text == "")
        {
            cheattext.text = "你沒作弊";
            cheattext.color = new Color32(0,173,3,255);
            panel1.color = new Color32(0, 255, 55, 255);
            text.color = new Color32(0,0,0,255);
        }
        else
        {
            cheattext.text = "詐胡";
            cheattext.color = new Color32(255,33,35,255);
            panel1.color = new Color32(255,0,0, 255);
            text.color = new Color32(255,255,255,255);
            taitext.text = "";
            tainum.text = "0";
        }
    }

    public int addc(Toggle toggle,Toggle antoggle,int n1,int n2,int n3,int status,int horizontal)
    {
        int returenum = maincounter(toggle,antoggle, n1, n2, n3, status);

        if(returenum == 3)
        {
            errortext.text += "第" + horizontal.ToString() + "行" +  "邏輯錯誤\n";
        }

        if (errortext.text == "")
        {
            cheattext.text = "你沒作弊";
            cheattext.color = new Color32(0, 173, 3, 255);
            panel1.color = new Color32(0, 255, 55, 255);
            text.color = new Color32(0, 0, 0, 255);
        }
        else
        {
            cheattext.text = "詐胡";
            cheattext.color = new Color32(255, 33, 35, 255);
            panel1.color = new Color32(255, 0, 0, 255);
            text.color = new Color32(255, 255, 255, 255);
            taitext.text = "";
            tainum.text = "0";
        }

        //if (returenum == 0)
        //{
        //    taitext.text += "碰\n";
        //}
        //else if(returenum == 1)
        //{
        //    taitext.text += "吃\n";
        //}
        //else if(returenum == 2)
        //{
        //    taitext.text += "槓\n";
        //}
        //else
        //{
        //    errortext.text += "第" + horizontal.ToString() + "行" +  "邏輯錯誤\n";
        //}  

        return returenum;
    }

    //其他台數
    public void othertai()
    {
        if (t1.isOn)
        {
            taitext.text += "獨聽        1台\n";
            sumtai += 1;
        }

        if (t2.isOn && t16.isOn)
        {
            taitext.text += "花台        1台\n";
            sumtai += 1;
        }
        else if(t2.isOn && !t16.isOn)
        {
            errortext.text += "e002" + "邏輯錯誤\n"; //e002
        }

        if (t6.isOn)
        {
            if (gang1.isOn || gang2.isOn || gang3.isOn || gang4.isOn || gang5.isOn || t16.isOn) 
            {
                taitext.text += "槓上開花    1台\n";
                sumtai += 1;
            }
            else
            {
                errortext.text += "e003" + "邏輯錯誤\n"; //e003
            }
        }

        //t3
        if (t3.isOn && an1.isOn && an2.isOn && an3.isOn && an4.isOn && an5.isOn)
        {
            taitext.text += "門清一摸三    3台\n";
            sumtai += 3;
        }
        else if (t3.isOn)
        {
            taitext.text += "自摸      1台\n";
            sumtai += 1;
        }
        else if (an1.isOn && an2.isOn && an3.isOn && an4.isOn && an5.isOn)
        {
            taitext.text += "門清      1台\n";
            sumtai += 1;
        }

        //t7
        if (t7.isOn && t3.isOn)
        {
            taitext.text += "海底撈月    1台\n";
        }

        //t9 t17
        if (t9.isOn)
        {
            taitext.text += "天聽      16台\n";
            sumtai += 16;
        }
        if (t17.isOn)
        {
            taitext.text += "地聽       8台\n";
            sumtai += 8;
        }

        //t8 t10 t11
        if (t8.isOn)
        {
            taitext.text += "天胡      24台\n";
            sumtai += 24;
        }
        if (t10.isOn)
        {
            taitext.text += "地胡      16台\n";
            sumtai += 16;
        }
        if (t11.isOn)
        {
            taitext.text += "人胡      16台\n";
            sumtai += 16;
        }
        

        //t12
        if (t12.isOn)
        {
            taitext.text += "花槓      2台\n";
            sumtai += 2;           
        }

        //t13
        if (t13.isOn && dropdown.value != 0)
        {
            taitext.text += "莊家連" + dropdown.value.ToString() + "拉" + dropdown.value.ToString() + "  " + (dropdown.value + dropdown.value + 1).ToString() + "台\n";
            sumtai += dropdown.value + dropdown.value + 1;
        }
        else if (t13.isOn)
        {
            taitext.text += "莊家      1台\n";
            sumtai += 1;
        }

        //t14
        if (t14.isOn)
        {
            if (gang1.isOn || gang2.isOn || gang3.isOn || gang4.isOn || gang5.isOn)
            {
                taitext.text += "搶槓      1台\n";
                sumtai += 1;
            }
            else
            {
                errortext.text += "e001" + "邏輯錯誤\n"; //e001
            }
        }

        //t15
        if (t15.isOn && !t3.isOn)
        {
            taitext.text += "河底撈魚   1台\n";
            sumtai += 1;
        }       

        if (g1s == 1 && g2s == 1 && g3s == 1 && g4s == 1 && g5s == 1 && !t3.isOn && !t1.isOn && !havestr)
        {
            taitext.text += "平胡      2台\n";
            sumtai += 2;
        }

        if (!an1 && !an2 && !an3 && !an4 && !an5)
        {
            taitext.text += "全求人    2台\n";
            sumtai += 1;
        }

        //暗刻
        if (sumone == 5)
        {
            taitext.text += "五暗刻    8台\n";
            sumtai += 8;
        }
        else if (sumone == 4)
        {
            taitext.text += "四暗刻    5台\n";
            sumtai += 5;
        }
        else if (sumone == 3)
        {
            taitext.text += "三暗刻    2台\n";
            sumtai += 2;
        }

        if(!havestr && !t16.isOn)
        {
            taitext.text += "無花無字  2台\n";
            sumtai += 2;
        }

        if(g1s == 0 && g2s == 0 && g3s == 0 && g4s == 0 && g5s == 0)
        {
            taitext.text += "碰碰胡    4台\n";
            sumtai += 4;
        }
    }

    //主要判斷
    public int maincounter(Toggle toggle,Toggle antoggle,int index1,int index2,int index3,int status)
    {
        string slist = null;

        if(g1[index1].GetComponent<slotitem>().mahkind != "wing" && g1[index1].GetComponent<slotitem>().mahkind != "uan")
        {
            slist = soft(int.Parse(g1[index1].GetComponent<slotitem>().mahnum), int.Parse(g1[index2].GetComponent<slotitem>().mahnum), int.Parse(g1[index3].GetComponent<slotitem>().mahnum));
        }

        //吃碰槓判斷
        if (g1[index1].GetComponent<slotitem>().mahkind == g1[index2].GetComponent<slotitem>().mahkind && g1[index2].GetComponent<slotitem>().mahkind == g1[index3].GetComponent<slotitem>().mahkind)
        {
            if(g1[index1].GetComponent<slotitem>().mahnum == g1[index2].GetComponent<slotitem>().mahnum && g1[index2].GetComponent<slotitem>().mahnum == g1[index3].GetComponent<slotitem>().mahnum)
            {
                if (g1[index1].GetComponent<slotitem>().mahnum == mywing) 
                { 
                    taitext.text += "自風        1台\n"; 
                    sumtai += 1; 
                }
                if (g1[index1].GetComponent<slotitem>().mahnum == allwing) 
                { 
                    taitext.text += "場風        1台\n"; 
                    sumtai += 1; 
                }

                if (g1[index1].GetComponent<slotitem>().mahkind == "uan")
                {
                    taitext.text += "三元牌      1台\n";
                    sumtai += 1;
                }

                if (g1[index1].GetComponent<slotitem>().mahkind == "wing")
                {
                    havestr = true;                   
                }

                if (toggle.isOn)
                {
                    status = 2; //槓
                    if (antoggle.isOn)
                    {
                        sumone++;
                    }
                }
                else
                {
                    status = 0; //碰  
                    if (antoggle.isOn)
                    {
                        sumone++;
                    }
                }
            }
            else if (slist == "123" || slist == "234" || slist == "345" || slist == "456" || slist == "567" || slist == "678" || slist == "789")
            {
                status = 1; //吃
            }
            else
            {
                status = 3;
            }
        }
        else
        {
            status = 3;
        }

        return status;
    }

    public void twoerrorif(int index1)
    {
        if(g1[index1].GetComponent<slotitem>().mahkind == "wing")
        {
            havestr = true;
        }
    }

    public string soft(int s1,int s2,int s3)
    {
        List<int> num = new List<int>() { s1, s2, s3 };

        if(num[0] > num[1])
        {
            var n1 = num[0];
            num[0] = num[1];
            num[1] = n1;
        }
        if(num[1] > num[2])
        {
            var n2 = num[1];
            num[1] = num[2];
            num[2] = n2;
        }
        if (num[0] > num[1])
        {
            var n3 = num[0];
            num[0] = num[1];
            num[1] = n3;
        }
        return num[0].ToString() + num[1].ToString() + num[2].ToString();
    }

    //打開panel
    public void toopen()
    {  
        Rect.position = new Vector3(Screen.width / rectpos, Rect.position.y, 0f);
        isopen = true;
    }
    public void tooff()
    {
        Rect.position = new Vector3(Rect.position.x - Screen.width, Rect.position.y, 0f);
        isopen = false;
    }
}
