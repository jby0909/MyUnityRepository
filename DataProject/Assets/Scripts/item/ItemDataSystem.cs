using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataSystem : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField descriptionInputField;
    public Button loadButton;
    public bool interactable;
    ItemData itemData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //nameInputField.onEndEdit.AddListener(ValueChanged);
        //�� ������� ����� ����� ����Ƽ �ν����Ϳ��� ������ ����

        loadButton.interactable = interactable;
        //��ư�� interractable�� ����ڿ��� ��ȣ�ۿ� ���θ� ������ �� ����ϴ� ��

        nameInputField.onEndEdit.AddListener(InputItemName);
        descriptionInputField.onEndEdit.AddListener(InputItemDescription);
        itemData = new ItemData();
    }

    //1. public���� ���� �Լ��� ����Ƽ �ν����Ϳ��� ���� �����ϰڽ��ϴ�
    //2. public�� �ƴ� �Լ��� ��ũ��Ʈ �ڵ带 ���� ����� �������ְڽ��ϴ�



    public void Sample()
    {
        Debug.Log("INPUT FIELD'S ON VALUE CHANGED");
    }

    /// <summary>
    /// �۾��� ������ �Ǿ��� �� �ش� ������ �Է������� �˷��ִ� �Լ�
    /// </summary>
    /// <param name="text">����</param>
    void ValueChanged(string text)
    {
        Debug.Log($"{text} �Է� �߽��ϴ�.");
    }

    public void InputItemName(string text)
    {
        itemData.itemName = text;
        Debug.Log(itemData.itemName);
    }

    public void InputItemDescription(string text)
    {
        itemData.itemDescription = text;
        Debug.Log(itemData.itemDescription);
    }

    public void SaveData()
    {
        Debug.Log(itemData.itemName);
        Debug.Log(itemData.itemDescription);
        PlayerPrefs.SetString("ItemName", itemData.itemName);
        PlayerPrefs.SetString("ItemDescription", itemData.itemDescription);
    }

    public void ClearData()
    {
        PlayerPrefs.DeleteKey("ItemName");
        PlayerPrefs.DeleteKey("ItemDescription");
        nameInputField.text = string.Empty;
        descriptionInputField.text = string.Empty;
    }
    


}
