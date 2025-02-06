using Unity.VisualScripting;
using UnityEngine;

public class UserDataSystem : MonoBehaviour
{
    public UserData data01;
    public UserData data02;

    //PlayerPrefs ���
    //1. DeleteAll() ���� ���
    //2. DeleteKey(Ű �̸�) : �ش� Ű�� �ش��ϴ� ���� ����
    //3. GetFloat/Int/String(Ű �̸�) : Ű�� �ش��ϴ� ���� return��
    //                                    ������ Ÿ�Կ� ���缭 ���
    //4. SetFloat/Int/String(Ű �̸�, ��) : �ش� Ű - ���� ����
    //                                      ������ ���� Ű�� �ִٸ� ���� �����
    //5. HashKey(Ű �̸�) : �ش� Ű�� �����ϴ����� Ȯ��

    private void Start()
    {
        data01 = new UserData();
        //Ŭ���� ���� ���
        //Ŭ��������(���۷���)�� = new ������();

        data02 = new UserData("sample0206", "test", "abc123", "sample0206@unity.com");

        //data02�� �����͸� ���̵�,�̸�,��й�ȣ,�̸��� ������ ������
        string data_value = data02.GetData();
        Debug.Log(data_value);

        PlayerPrefs.SetString("data01", data_value); // �� �����ͷ� data01�� ����
        //PlayerPrefs.Save(); // ����� �� ���� ����

        data01 = UserData.SetData(data_value); // data01�� ���޹��� �����ͷ� ����
        Debug.Log(data01.GetData()); // data01�� ����� ���޵ƴ��� Ȯ��
    }

}
