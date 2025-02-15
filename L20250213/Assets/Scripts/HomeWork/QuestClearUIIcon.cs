using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class QuestClearUIIcon : MonoBehaviour, IPointerClickHandler
{
    GameObject questClearUI;
    Text expText;
    Text moneyText;
    public Quest quest;


    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("아이콘 클릭함");
        questClearUI = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
        questClearUI.SetActive(true);
    }

    

    public void OnClickRewardOkButton()
    {
        PlayerController.exp += quest.보상.경험치;
        PlayerController.money += quest.보상.돈;

        expText.text = $"Exp : {PlayerController.exp}";
        moneyText.text = $"Gold : {PlayerController.money}";
        Destroy(questClearUI);
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        expText = GameObject.Find("ExpText").GetComponent<Text>();
        moneyText = GameObject.Find("GoldText").GetComponent<Text>();
    }

}
