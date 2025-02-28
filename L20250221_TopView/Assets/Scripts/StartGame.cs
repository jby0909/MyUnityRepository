using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void OnStartButton()
    {
        RoomManager.ChangeScene("StartMap", 0);
    }
}
