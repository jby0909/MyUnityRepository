
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogExample : MonoBehaviour
{
    public List<string> dialogList = new List<string>();
    public Queue<string> dialogQueue = new Queue<string>();
    public Text text;
    public Text peopleTypeText;
    PEOPLE peopleType;
    enum PEOPLE
    {
        NPC,
        Me
    }

    private void Start()
    {
        dialogList.Add("�������.");
        dialogList.Add("���� ȸ�� ���� �ֳ���?");
        dialogList.Add("�̷�, ���� ��� ���׿�.");
        dialogList.Add("����� �ֽ� �� ������?");
        dialogList.Add("�׷� �����첿�� 20���� ���ؿ�����.");
        dialogList.Add("�� �˰ڽ��ϴ�.");

        foreach(string dialog in dialogList)
        {
            dialogQueue.Enqueue(dialog);
        }

        
    }

    void PeopleTyepe()
    {

    }

    public void PrintDialog()
    {
        if(dialogQueue.Count > 0)
        {
            text.text = "";
            if(dialogQueue.Count % 2 == 0)
            {
                peopleTypeText.text = PEOPLE.NPC.ToString();
            }
            else
            {
                peopleTypeText.text = PEOPLE.Me.ToString();
            }
            string dialog = dialogQueue.Dequeue();
            StartCoroutine(PrintDelay(dialog));
        }
        
    }

    IEnumerator PrintDelay(string dialog)
    {
        foreach(char c in dialog)
        {
            text.text += c;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
