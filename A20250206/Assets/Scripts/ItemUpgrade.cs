using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ItemUpgrade : MonoBehaviour
{
    ItemData itemData;
    public Text upgradeText;
    public Text itemDescriptionText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemData = new ItemData();
        //LoadData();
        //itemDescriptionText.text = $"아이템 이름: {itemData.itemName}" +
        //        $" +{itemData.itemLevel}" + $"\n아이템 설명 : \n{itemData.itemDescription}";
    }

    public void OnClickButton()
    {
        int rand = Random.Range(0, 100);
        if(rand < 50)
        {
            itemData.itemLevel += 1;
            upgradeText.text = "강화확률 50%\n" + $"강화 성공! 아이템 레벨 : {itemData.itemLevel}";
            itemData.itemDescription = $"This Axe is level {itemData.itemLevel}";
            itemDescriptionText.text = $"아이템 이름: \n{itemData.itemName}" +
                $" +{itemData.itemLevel}" + $"\n\n아이템 설명 : \n{itemData.itemDescription}";


        }
        else
        {
            upgradeText.text = "강화확률 50%\n" + $"강화 실패! 아이템 레벨 : {itemData.itemLevel}";
            
        }
    }

    public void SaveData()
    {
        File.WriteAllText(Application.dataPath + "/ItemData.json", JsonUtility.ToJson(itemData));
    }
    
    public void LoadData()
    {
        string load_json = File.ReadAllText(Application.dataPath + "/ItemData.json");
        itemData = JsonUtility.FromJson<ItemData>(load_json);
        upgradeText.text = "강화확률 50%\n" + $"강화 성공! 아이템 레벨 : {itemData.itemLevel}";
        itemDescriptionText.text = $"아이템 이름: \n{itemData.itemName}" +
                $" +{itemData.itemLevel}" + $"\n\n아이템 설명 : \n{itemData.itemDescription}";

    }
}
