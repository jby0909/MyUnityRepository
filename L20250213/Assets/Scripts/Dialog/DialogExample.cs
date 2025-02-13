
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
        dialogList.Add("어서오세요.");
        dialogList.Add("마나 회복 물약 있나요?");
        dialogList.Add("이런, 남은 재고가 없네요.");
        dialogList.Add("만들어 주실 수 없나요?");
        dialogList.Add("그럼 도마뱀꼬리 20개를 구해오세요.");
        dialogList.Add("네 알겠습니다.");

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
