using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : MonoBehaviour
{
    public GameObject Show;
    public GameObject Show1;
    public string[] ThisShow;

    public int ThisOne;

    public int ThisType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseUp()//点击npc
    {
        if (ThisType == 1)//根据数字判断当前是哪个npc
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PeopleMove>().Score >= 10)//根据每个npc的过关条件给玩家加血，显示npc对话
            {
                if (ThisOne == 0)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PeopleMove>().HP += 50;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PeopleMove>().jineng += 1;
                }
                Show.SetActive(true);
                if (ThisOne < ThisShow.Length)
                    Show.transform.GetChild(0).GetComponent<Text>().text = ThisShow[ThisOne];//显示对话
                ThisOne += 1;//对话下一句
                if (ThisOne > ThisShow.Length)//对话显示完毕
                {
                    Show.SetActive(false);
                    this.gameObject.SetActive(false);
                }
            }


        }
        else if (ThisType == 2)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PeopleMove>().Score >= 20)
            {
                if (ThisOne == 0)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PeopleMove>().HP += 50;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PeopleMove>().jineng += 1;
                }
                    
                Show.SetActive(true);
                if (ThisOne < ThisShow.Length)
                    Show.transform.GetChild(0).GetComponent<Text>().text = ThisShow[ThisOne];
                ThisOne += 1;
                if (ThisOne > ThisShow.Length)
                {
                    Show.SetActive(false);
                    this.gameObject.SetActive(false);
                }
            }


        }
        else if (ThisType == 3)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<PeopleMove>().Score >= 30)
            {
                if (ThisOne == 0)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PeopleMove>().HP +=100;
                  
                }

                Show.SetActive(true);
                if (ThisOne < ThisShow.Length)
                    Show.transform.GetChild(0).GetComponent<Text>().text = ThisShow[ThisOne];
                ThisOne += 1;
                if (ThisOne > ThisShow.Length)
                {
                    Show.SetActive(false);
                    this.gameObject.SetActive(false);
                    Show1.SetActive(true);
                }
            }


        }
        else
        {
            Show.SetActive(true);
            if (ThisOne < ThisShow.Length)
                Show.transform.GetChild(0).GetComponent<Text>().text = ThisShow[ThisOne];
            ThisOne += 1;
            if (ThisOne > ThisShow.Length)
            {
                Show.SetActive(false);
            }

        }

    }
}
