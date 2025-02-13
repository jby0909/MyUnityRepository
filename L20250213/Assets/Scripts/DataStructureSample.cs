using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//����Ƽ���� Ư�� ������ �Ǵ� ����� �����ϱ� ���� ���Ϲ� �ڷ����� ���� �� �ʼ�
//�⺻ �ڷ��� �̿ܿ� Ư�� ���, �۾��� ������ �� �ִ� ������ ����ü�� '�ڷᱸ��'�� ��(������ ���� ����)

//���� Ȱ��Ǵ� �ڷᱸ��
//1. ����Ʈ(List) : ������� ������ �� �ְ�, ���� �����͸� �߰�, ����, �˻��� �� �ִ� ������ ������ �迭
//2. ��ųʸ�(dictionary) : Ű-�� ���� ��� ������ �� �ִ� ����(json���Ͽ����� Ȯ�� ����)
//3. ť(Queue) : �ڷḦ ���Լ���(FIFO)�� ������ �� ����� �ڷᱸ��
//4. ����(Stack) : �ڷḦ ���Լ���(LIFO)�� ������ �� ����� �ڷᱸ��
//5. �ؽü�(HashSet) : �������� �ߺ��� ���� ������� �ʴ� ���, ���� ������ �ʿ� ���� ���

public class DataStructureSample : MonoBehaviour
{
    //ť(Queue)
    //�������ִ� ��� : ����, ����, ù��° �� ��ȸ ���
    //���� : �߰��� �ִ� �����͸� �����ϴ� �κп��� �ſ� ��ȿ����

    //string ������ ���� ������ �� �ִ� ť
    public Queue<string> stringQueue = new Queue<string>();

    private void Start()
    {
        //1) ť�� ������ �߰�
        stringQueue.Enqueue("�� �� �����ּ���.");
        stringQueue.Enqueue("���� ������?");
        stringQueue.Enqueue("�ٳ��� ���� 20���� �ʿ��ؿ�.");
        stringQueue.Enqueue("���͵帮�ڽ��ϴ�.");
        stringQueue.Enqueue("�����մϴ�.");

        //2)ù��° ������ ��ȸ
        foreach(string dialog in stringQueue)
        {
            Debug.Log(stringQueue.Peek()); //ť�� ����� ���� �� ���� ���� return��
        }

        //3) ť�� ������ ����
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        //ť�� ����� �� ���� ���� return��
        //�߰������� �� ���� ���� ������

    }
}
