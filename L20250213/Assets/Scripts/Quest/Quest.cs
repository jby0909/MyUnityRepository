using System;
using UnityEngine;

//����Ʈ ����
public enum QuestType
{
    normal,
    daily,
    weekly,
}
//�Ϲ� ����Ʈ : Ŭ�����ϸ� ���̻� �� �� ����
//���ϸ� ����Ʈ : ������ �������� ����Ʈ�� ����
//��Ŭ�� ����Ʈ : �ָ� �������� ����Ʈ�� ����



[CreateAssetMenu(fileName = "Quest", menuName = "Quest/quest")]
public class Quest : ScriptableObject
{
    public QuestType ����Ʈ����;
    public Reward ����;
    public Requirement �䱸����;

    [Header("����Ʈ ����")]
    public string ����; //����Ʈ�� ����
    public string ��ǥ; //����Ʈ�� ��ǥ
    [TextArea]public string ����; //����Ʈ�� ���� ����

    public bool ����; //����Ʈ�� ���� ���� üũ
    public bool �������; //����Ʈ�� ���� �������� Ȯ���ϴ� �뵵�� ���
}

//�䱸 ���ǿ� ���� ��ũ���ͺ� ������Ʈ ����
[Serializable]
[CreateAssetMenu(fileName = "Requirement", menuName = "Quest/requirement")]
public class Requirement : ScriptableObject
{
    public int Ȳ�ݰ���;
    public int �������Ȳ�ݰ���;
}

[Serializable]
[CreateAssetMenu(fileName = "Reward", menuName = "Quest/reward")]
public class Reward : ScriptableObject
{
    public int ��;
    public float ����ġ;
}
