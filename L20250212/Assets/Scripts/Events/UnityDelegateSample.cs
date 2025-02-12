using System;
using UnityEngine;
using UnityEngine.UI;

//delegate�� �̿��ϸ� �̺�Ʈ�� �� ���� © �� ����
class MeetEvent
{
    public delegate void MeetEventHandler(string message);
    public event MeetEventHandler meethandler;

    public void Meet()
    {
        meethandler("���� �͵� �ο��ε� ��𰡼� ���� ����...");
    }
}

namespace bootcamp0212
{
    public class UnityDelegateSample : MonoBehaviour
    {

        public Text messageUI;
        MeetEvent meetEvent = new MeetEvent();
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
            meetEvent.meethandler += EventMessage;
        }

        private void EventMessage(string message)
        {
            messageUI.text = message;
    
        }

        public void OnMeetButtonEnter()
        {
            meetEvent.Meet();
        }

    
    }

}

