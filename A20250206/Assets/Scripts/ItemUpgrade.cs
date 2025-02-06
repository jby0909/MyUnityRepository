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
        //itemDescriptionText.text = $"������ �̸�: {itemData.itemName}" +
        //        $" +{itemData.itemLevel}" + $"\n������ ���� : \n{itemData.itemDescription}";
    }

    public void OnClickButton()
    {
        int rand = Random.Range(0, 100);
        if(rand < 50)
        {
            itemData.itemLevel += 1;
            upgradeText.text = "��ȭȮ�� 50%\n" + $"��ȭ ����! ������ ���� : {itemData.itemLevel}";
            itemData.itemDescription = $"This Axe is level {itemData.itemLevel}";
            itemDescriptionText.text = $"������ �̸�: \n{itemData.itemName}" +
                $" +{itemData.itemLevel}" + $"\n\n������ ���� : \n{itemData.itemDescription}";


        }
        else
        {
            upgradeText.text = "��ȭȮ�� 50%\n" + $"��ȭ ����! ������ ���� : {itemData.itemLevel}";
            
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
        upgradeText.text = "��ȭȮ�� 50%\n" + $"��ȭ ����! ������ ���� : {itemData.itemLevel}";
        itemDescriptionText.text = $"������ �̸�: \n{itemData.itemName}" +
                $" +{itemData.itemLevel}" + $"\n\n������ ���� : \n{itemData.itemDescription}";

    }
}
