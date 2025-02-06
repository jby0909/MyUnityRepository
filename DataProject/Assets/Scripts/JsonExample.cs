using UnityEngine;

[System.Serializable]
public class SampleData
{
    public int i;
    public float f;
    public bool b;
    public Vector3 v;
    public string s;
    public int[] iArray;
}

public class JsonExample : MonoBehaviour
{
    
    void Start()
    {
        SampleData sampleData = new SampleData();
        sampleData.i = 0;
        sampleData.f = 1.0f;
        sampleData.b = false;
        sampleData.v = Vector3.zero;
        sampleData.s = "hello";
        sampleData.iArray = new int[] { 1, 2, 3, 4, 5 };


        //sampleData Ŭ������ ���� ���� json ����(string)
        string json_data = JsonUtility.ToJson(sampleData);
        Debug.Log(json_data);

        //json_data�� ���� ���޹��� ������ ���� SampleData ������Ʈ
        var sampleData2 = JsonUtility.FromJson<SampleData>(json_data);
        Debug.Log(sampleData2.s);
    }

    
    void Update()
    {
        
    }
}
