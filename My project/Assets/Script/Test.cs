using UnityEngine;
// using�� ������ ���� ���� �ڵ忡�� ����ϴ� ���Դϴ� ��� ��
// ����Ƽ���� ����Ƽ�� Ȱ���� �۾��ϴ� ��ũ��Ʈ��� ���� �ڵ带 �ݵ�� �߰�(�ڵ����� �߰��Ǿ�����)

//���ӽ����̽��� Ư�� ����� �ϴ� Ŭ������ ��ǥ���� �̸����μ� ���
namespace UnityTutorial2
{
    //UnityTutorial �������� ������� SampleA Ŭ����
    public class SampleA
    {

    }
}

public class SampleA
{

}

/// <summary>
/// ó������ ���� ����Ƽ�� ��ũ��Ʈ
/// </summary>
public class Test : MonoBehaviour
    //MonoBehaviour�� Ŭ������ �������� ��� ����Ƽ ���� �����ϴ� ������Ʈ�� ��ũ��Ʈ�� ������ �� �ְ� ����
    // �߰������� ����Ƽ���� �������ִ� ����� ����� �� ���
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Game Start!");  
    }

    int count = 0;

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{count} �¿� �ݺ� �ٱ�");
        count++;
    }
}
