using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextCount : MonoBehaviour
{
    //�ؽ�Ʈ�� ī��Ʈ�� ����ϴ� ����� ����
    //ī��Ʈ�� ��� 1�� �����ϴ� ���·� ó��
    public Text countText;
    int count = 0;
   
    void Start()
    {

        //StartCoroutine("�Լ��� �̸�(IEnumerator ������ �Լ�)");
        //1. ���ڿ��� ���� �Լ��� ã�Ƽ� �����ϴ� ����
        // >> ��Ÿ�� �߻��ص� ������ �߻����� ����. ������ ����� ������� ����.
        //StopCoroutine()�� ���� �ܺο����� �����ϴ� ���� ����
        //������ ��� �����·� ���

        //StartCoroutine(�Լ��� �̸�());
        //2. �ش� �Լ��� ȣ���� ���� ����� ��ȯ�ϴ� ����
        // >> ��Ÿ �߻� �� ���� üũ ����
        //�� ������δ� StopCoroutine()�� ���� �ܺο����� ���� ����� ����� �� ����


        //�ش� �ڷ�ƾ ���� ���� ����
        StartCoroutine("CountPlus");
        //StopCoroutine("CountPlus");

        //������ �� ����(���� ����� �ȵ�. ����ϰ� ������ ����������)
        //�Լ� ���� ���� ���
        //StartCoroutine(CountPlus());
    }
    IEnumerator CountPlus()
    {
        while (true)
        {
            count++;
            countText.text = count.ToString("N0");
            //C#�� ToString()�� ���� ���� ���·� ������ ����
            //N0�� ���� 3�ڸ� �������� ,�� ǥ���ϴ� format(1000 -> 1,000)

            yield return new WaitForSeconds(1.0f);
            //���� �������� �Ѿ
        }


        //Debug.Log("�ƾ� ����ũ �׽�Ʈ");
        //yield return new WaitForSeconds(1);

        ////yield�� �Ͻ������� CPU�� ������ �ٸ� �Լ��� �����ϴ� Ű����

        //Debug.Log("�丸 �԰� �ð�");
        //yield return new WaitForSeconds(5);

        //Debug.Log("�ٽ� ���� �غ���?");
    }
}
