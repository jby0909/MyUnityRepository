using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static Text HPText;
    public static Text GoldText;
    public static Text ArrowText;
    public static Text StageLevelText;

    public static string nowSceneName;

    

    private void Awake()
    {
        HPText = GameObject.Find("HPText").GetComponent<Text>();
        GoldText = GameObject.Find("GoldText").GetComponent<Text>();
        ArrowText = GameObject.Find("ArrowText").GetComponent<Text>();
        StageLevelText = GameObject.Find("StageLevelText").GetComponent<Text>();
        nowSceneName = SceneManager.GetActiveScene().name;
        StageLevelText.text = $"Stage : {RoomManager.stageLevelcp}";
    }

    public void OnRestartButton()
    {
        RoomManager.ChangeScene(nowSceneName, RoomManager.doorNumber);
        PlayerController.Initialize();
        RoomManager.CurrentEnemyManager.enemy_count = RoomManager.stageLevelcp * 2;
        BossController.isDead = false;
    }

    public void OnExitButton()
    {
        RoomManager.ChangeScene("StartScene", RoomManager.doorNumber);
        PlayerController.Initialize();
        RoomManager.stageLevelcp = 0;
    }
   
}
