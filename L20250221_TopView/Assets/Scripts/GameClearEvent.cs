using UnityEngine;

public class GameClearEvent : MonoBehaviour
{
    public GameObject canvas;
    bool isSet = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�̺�Ʈ �ý������� �����ϸ� ������ ����(�ϴ� �ӽ÷�  update������ Ȯ��)
        if(ItemKeeper.hasDia >= 0 && !isSet)
        {
            canvas.transform.Find("GameClearUI").gameObject.SetActive(true);
            isSet = true;
        }
    }
}
