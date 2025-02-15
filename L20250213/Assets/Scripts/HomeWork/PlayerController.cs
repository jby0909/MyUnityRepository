
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int hp = 100;
    public static int money = 0;
    public static float exp = 0;
    int speed = 10;
    int itemCount = 0;
    public Quest quest;
    Text hpText;
    Text expText;
    Text moneyText;
    GameObject questUI;
    //GameObject questClearUI;

    Text questText;
    Text questNameText;
    Text questActiveText;

    GameObject questClearUIIcon;
    

    QuestEvent questEvent = new QuestEvent();

    void Start()
    {
        hpText = GameObject.Find("HPText").GetComponent<Text>();
        hpText.text = $"HP : {hp}";
        expText = GameObject.Find("ExpText").GetComponent<Text>();
        expText.text = $"Exp : {exp}";
        moneyText = GameObject.Find("GoldText").GetComponent<Text>();
        moneyText.text = $"Gold : {money}";

        

        QuestEvent.QuestEventHandler += QuestClear;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -1) * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "item")
        {
            itemCount++;
            Destroy(other.gameObject);
            questActiveText.text = questEvent.QuestRunning(itemCount);

        }
        else if(other.gameObject.tag == "npc")
        {
            // 퀘스트창 열기
            questUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
            questUI.SetActive(true);

            questText = questUI.transform.GetChild(3).gameObject.GetComponent<Text>();
            questNameText = questUI.transform.GetChild(4).gameObject.GetComponent<Text>();

            questText.text = quest.설명;
            questNameText.text = quest.제목;
        }
        else if(other.gameObject.tag == "monster")
        {
            hp -= 10;
            hpText.text = $"HP : {hp}";
        }
    }

    private void QuestClear(object sender, EventArgs e)
    {
        quest.진행상태 = false;
        quest.성공 = true;
        
        questActiveText.gameObject.SetActive(false);
        questClearUIIcon = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
        questClearUIIcon.SetActive(true);
        //questClearUI = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
        //questClearUI.SetActive(true);
    }

    //public void OnClickRewardOkButton()
    //{
    //    exp += quest.보상.경험치;
    //    money += quest.보상.돈;

    //    expText.text = $"Exp : {exp}";
    //    moneyText.text = $"Gold : {money}";
    //    Destroy(questClearUI);
    //}

    public void OnClickOKButton()
    {
        quest.진행상태 = true;
        GameObject.Find("Quest").SetActive(false);
        GameObject.Find("NPC").SetActive(false);
        GameObject.Find("Create").transform.GetChild(0).gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.GetChild(2).gameObject.SetActive(true);
        questActiveText = GameObject.Find("questActiveText").GetComponent<Text>();
    }

}
