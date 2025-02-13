using System;
using UnityEngine;


[Serializable]
[CreateAssetMenu(menuName ="Bootcamp/Audio", fileName ="Audio_")]
public class AudioEvent : ScriptableObject
{
    public event Action<string> OnPlay;
    public void Play(string name)
    {
        if(OnPlay != null)
        {
            OnPlay.Invoke(name);
            //Invoke�� �̺�Ʈ ����� �Լ�
        }
    }
}
