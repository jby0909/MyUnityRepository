using System.IO;
using UnityEngine;
//Json 사용 방법
//1. 읽을 수 있는 데이터 형태로 만들어 줌
//2. 파일 경로 기반으로 json파일을 찾아서 내부의 텍스트를 읽어냄
//3. 읽어낸 데이터를 통해 클래스화를 진행
//4. 마음껏 쓰기

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
                                            //작업 폴더를 의미(유니티에서  Assets폴더 위치)
        var data = JsonUtility.FromJson<Item01>(load_json);
        Debug.Log(data.name);

        data.name = "마음대로 바꿔보기";
        data.description = "와아아와오아아ㅘ";

        File.WriteAllText(Application.dataPath + "/item02.json", JsonUtility.ToJson(data));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
