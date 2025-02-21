using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomManager : MonoBehaviour
{

    public static int doorNumber = 0; //�� ��ȣ

    public static void ChangeScene(string sceneName, int door)
    {
        Debug.Log($"���� door Number : {doorNumber} ");
        doorNumber = door;
        SceneManager.LoadScene(sceneName);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
