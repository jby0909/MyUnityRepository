using UnityEngine;

[System.Serializable]
public class UserData 
{
    public string UserID;
    public string UserName;
    public string UserPassword;
    public string UserEmail;

    //������(Constructor)
    //Ŭ���� �̸��� ������ �޼ҵ带 �ǹ�
    //��ȯ Ÿ���� ���� ���� �޼ҵ�
    //���� �������� ���� ��쿡�� �⺻ �����ڷ� ó����

    //�⺻ ������ = Ŭ������ �̸��� ������ �޼ҵ�, �Ű������� ���� ���� ����

    //���̵�, �̸�, ��й�ȣ, �̸��� ������� �ۼ��ϸ� ������ �� �ִ� UserData

    public UserData()
    {

    }
    public UserData(string userID, string userName, string userPassword, string userEmail)
    {
        UserID = userID;
        UserName = userName;
        UserPassword = userPassword;
        UserEmail = userEmail;
    }

    /// <summary>
    /// �����͸� �ϳ��� ���ڿ��� return�ϴ� �ڵ�
    /// </summary>
    /// <returns>���̵�,�̸�,��й�ȣ,�̸��� ������ ó��</returns>
    public string GetData() => $"{UserID},{UserName},{UserPassword},{UserEmail}";
    //1��¥�� return�ڵ带 ���� ��� {} ��� =>�� �ۼ� ����


    /// <summary>
    /// �����Ϳ� ���� ������ ���޹ް� UserData�� return�ϴ� �ڵ�
    /// </summary>
    /// <param name="data"></param>
    /// <returns>���̵�,�̸�,��й�ȣ,�̸��� ������ �ۼ��� ������</returns>
    public static UserData SetData(string data)
    {
        string[] data_value = data.Split(',');
        //���ڿ�.Split(",") �ش� ���ڿ��� ()�ȿ� �־��� ,�� �������� �߶� �迭�� �������
        //�迭�� 0������ �����͸� üũ(�ε���)
        return new UserData(data_value[0], data_value[1], data_value[2], data_value[3]);
    }
}
