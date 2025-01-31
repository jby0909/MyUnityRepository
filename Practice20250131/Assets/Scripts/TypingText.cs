using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypingText : MonoBehaviour
{
    public Text message; //Ÿ������ �ؽ�Ʈ
    [SerializeField][TextArea]private string content; // ����� ����
    [SerializeField] private float delay = 0.2f; //�д� �ӵ�

    void Start()
    {
        
    }

    public void OnMessageButtonClick()
    {
        StartCoroutine("Typing");
    }

    public void ByTwo()
    {
        if (delay == 0.2f)
        {
            delay = 0.1f;
        }
        else
            delay = 0.2f;
    }

    IEnumerator Typing()
    {
        message.text = ""; // ���� ȭ���� �޼����� ����
        int typing_count = 0;

        //���� ī��Ʈ�� �������� ���̿� �ٸ��ٸ�
        while(typing_count != content.Length)
        {
            if(typing_count < content.Length)
            {
                message.text += content[typing_count].ToString();
                //���� ī��Ʈ�� �ش��ϴ� �ܾ� �ϳ��� �޼��� �ؽ�Ʈ UI�� ����
                typing_count++;
                //ī��Ʈ�� 1 ������Ŵ
            }
            yield return new WaitForSeconds(delay);
        }
        
    }
}
