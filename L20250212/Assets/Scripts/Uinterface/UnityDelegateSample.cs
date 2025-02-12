using System;
using UnityEngine;


//����Ƽ���� �������ִ� ��������Ʈ
//1. using System; �ʿ�

public class UnityDelegateSample : MonoBehaviour
{
    //1) Action delegate
    //��ȯ Ÿ���� ���� ���� ����(void)�� �븮��
    //Action delegate��;
    Action action;

    //2. �Ű������� �ִ� ���
    //Action<T> delegate��;
    Action<int> action2;

    Action<string, int> action3;

    //2) Func delegate
    //��ȯ Ÿ���� ������ ������ �븮��
    Func<int> func01;
    Func<int, int, int> func02;
    //�Ű�����(int, int) ��ȯŸ�� int
    Func<int, int, string> func03;
    //�Ű�����(int, int) ��ȯŸ�� string

    void Start()
    {
        action = Sample;
        action();
        action2 = Sample;
        action3 = Sample;


        //�븮���� ��� �ٷ� ����� �����ؼ� ����ϴ°͵� ����
        func01 = () => 10;

        //����� ���
        //Func<T> �̸� = (�Ű����� �ۼ� ��ġ) => ��;
        Func<int> test = () => 25;

        //�Ű������� �����ϴ� ���
        func02 = (a, b) => a + b;

        //���� ������ ����� �ϴ� ���
        func02 = (a, b) =>
        {
            if(a > b)
            {
                a = b;
            }
            return a + b;
        };
        
    }

    //�����ε�(Overloading) ����
    //�Ϲ������� �Լ����� �����ϰ� ����
    //������ ���� ������ ��ų ��� ���� �̸��� �޼ҵ带 ����� �� ����
    
    //�Ű������� ����, Ÿ��, ������ �ٸ��ٸ� ���� �̸����� �޼ҵ� ���ǰ� ����

    //�����ε� ����� ���� �ణ�� ��Ȳ�� ���� �Ź� �޼ҵ��� �̸��� ������� �ʿ� ����
    //Ư�� ����� �����ϴ� ���� �̸��� �޼ҵ带 ����� �̸��� ������ �� ����

    //�������̵�(Overriding)
    //�θ� Ŭ�����κ��� ��� ���� �޼ҵ带 �ڽ� Ŭ�������� �������ϴ� ����
    //�������̽�, abstract class��� ����(����)�� �Ǿ��ִ� �޼ҵ带 ���޹��� �����
    //���������� �����ؾ� ��.

    //���� Ŭ�������� ���ϴ� ��ɿ� ���� ����
    //�������̽�, abstract class��� �������� Ʋ�� ���� ������ �ڵ� ���� ����
    //�ϳ��� ��ü�� ���� ���¸� ǥ���ϴ� ������ �������� ȿ����


    public void Sample() { }
    public void Sample(int a) { }

    public void Sample(string s, int a) { }
    public int Sample3() { return 0; } 

    
}
