using UnityEngine;

public class StartOrClearItem : MonoBehaviour
{
    public GameObject startOrClearitem;
    
    void Start()
    {
        if(RoomManager.stageLevelcp >= 3)
        {
            startOrClearitem.transform.Find("ItemBox").gameObject.SetActive(true);
            startOrClearitem.transform.Find("Key").gameObject.SetActive(false);

        }
        else
        {
            startOrClearitem.transform.Find("ItemBox").gameObject.SetActive(false);
            startOrClearitem.transform.Find("Key").gameObject.SetActive(true);
        }
    }

    
}
