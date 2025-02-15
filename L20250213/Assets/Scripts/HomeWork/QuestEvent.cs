using System;
using UnityEngine;

public class QuestEvent 
{
    public static event EventHandler QuestEventHandler;

    

    public string QuestRunning(int itemCount)
    {
        if(itemCount == 10)
        {
            QuestEventHandler(this, EventArgs.Empty);
            return "퀘스트 완료!";
        }
        else
        {
            return $"퀘스트 진행 현황 : {itemCount} / 10";
        }
    }
}
