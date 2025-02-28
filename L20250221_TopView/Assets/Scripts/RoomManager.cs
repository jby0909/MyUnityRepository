using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{

    public static int doorNumber = 0; //�� ��ȣ
    //public int stageLevel;
    public static int stageLevelcp = 0;

    private static EnemyManager currentEnemyManager = null;
    public static EnemyManager CurrentEnemyManager
    {
        get { return currentEnemyManager; }
    }

    public static void ChangeScene(string sceneName, int door = 0)
    {
        Debug.Log($"���� door Number : {doorNumber} ");
        doorNumber = door;
        currentEnemyManager = null;
        SceneManager.LoadScene(sceneName);
        

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentEnemyManager = GameObject.FindFirstObjectByType<EnemyManager>();

        if(currentEnemyManager != null)
        {
            currentEnemyManager.enemy_count = stageLevelcp * 2;
            currentEnemyManager.SpawnMonsterStage();
        }

        BossController.isDead = false;
        GameObject[] enters = GameObject.FindGameObjectsWithTag("Exit");

        for(int i = 0; i < enters.Length; i++)
        {
            var door = enters[i];
            var exit = door.GetComponent<Exit>();

            if(doorNumber == exit.doorNumber)
            {
                //�� ��ȣ�� ���� ���
                float x = door.transform.position.x;
                float y = door.transform.position.y;

                //���⿡ ���� ��ǥ ��ġ ����
                switch(exit.direction)
                {
                    case ExitDirection.up:
                        y += 1;
                        break;
                    case ExitDirection.down:
                        y -= 1;
                        break;
                    case ExitDirection.left:
                        x -= 1;
                        break;
                    case ExitDirection.right:
                        x += 1;
                        break;

                }

                var player = GameObject.FindGameObjectWithTag("Player");
                player.transform.position = new Vector3(x, y);
                break;
            }
        }
        }

    
}
