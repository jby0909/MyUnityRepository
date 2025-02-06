using System.IO;
using UnityEngine;
//Json ��� ���
//1. ���� �� �ִ� ������ ���·� ����� ��
//2. ���� ��� ������� json������ ã�Ƽ� ������ �ؽ�Ʈ�� �о
//3. �о �����͸� ���� Ŭ����ȭ�� ����
//4. ������ ����

[System.Serializable]
public class Item01
{
    public string name;
    public string description;
}

public class JsonLoadSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string load_json = File.ReadAllText(Application.dataPath + "/item01.json");
                                            //�۾� ������ �ǹ�(����Ƽ����  Assets���� ��ġ)
        var data = JsonUtility.FromJson<Item01>(load_json);
        Debug.Log(data.name);

        data.name = "������� �ٲ㺸��";
        data.description = "�;ƾƿͿ��ƾƤ�";

        File.WriteAllText(Application.dataPath + "/item02.json", JsonUtility.ToJson(data));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
