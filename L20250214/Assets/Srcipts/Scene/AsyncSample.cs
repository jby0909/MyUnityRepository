using System.Threading.Tasks;
using UnityEngine;

//����(syncronous)
//Task(�۾�)�� ���������� �����ϴ� ���
//�ϳ��� �۾��� �Ϸ�� �� ���� ���� �۾��� ��� ���·� ������

//�񵿱�(Asyncornous)
//���� ���� �۾�(Task)�� ���ÿ� ó���ϴ� ���

public class AsyncSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("�۾��� �����մϴ�.");
        Sample01();
        Debug.Log("Process A");

    }

    //async Ű����� �񵿱� �޼ҵ带 ������ �� ����ϴ� Ű����
    //�޼ҵ��� �������� �񵿱������� ����

    //�ش� Ű����� �Ϲ� �޼ҵ�, ���ٽ� � ���� �� ����
    //�ش� Ű���尡 ���� �޼ҵ�� Task, Task<T> �Ǵ� void�� return�ϰ� ��

    //Task�� �񵿱� �۾��� ��Ÿ���� Ŭ����
    //System.Threading.Tasks ������ ����
    
    //await�� �񵿱� �޼ҵ� ������ ���Ǵ� Ű����
    //�ش� Ű����� Task�� Task<T>�� return�ϴ� �޼ҵ峪 ǥ���� �տ� ����� �� ����

    //�ش� �񵿱� �۾��� �Ϸ�� ������ ������ �޼ҵ带 ������Ŵ
    //�۾��� �Ϸ�Ǹ� �ٽ� �ش� �޼ҵ带 ��� �����Ŵ

    private async void Sample01()
    {
        Debug.Log("Process B");
        await Task.Delay(10000);
        Debug.Log("Process C");
    }

    
}
