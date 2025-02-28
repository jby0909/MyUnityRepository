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
        //이벤트 시스템으로 구현하면 좋을것 같음(일단 임시로  update문에서 확인)
        if(ItemKeeper.hasDia >= 0 && !isSet)
        {
            canvas.transform.Find("GameClearUI").gameObject.SetActive(true);
            isSet = true;
        }
    }
}
