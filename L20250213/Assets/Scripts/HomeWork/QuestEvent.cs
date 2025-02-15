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
            return "����Ʈ �Ϸ�!";
        }
        else
        {
            return $"����Ʈ ���� ��Ȳ : {itemCount} / 10";
        }
    }
}
