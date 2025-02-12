using UnityEngine;

public class DelegateSample : MonoBehaviour
{
    //��������Ʈ(delegate)
    //�Լ��� ������ �� �ִ� ����, �Ϲ������� �븮�ڶ�� �θ�
    //�ش� �������� �Լ��� ���ԵǾ� �����Ƿ�, �ش� ������ �����ϸ� ������ �Լ��� ����Ǵ� ����� ������ ����.

    //���� ���
    //���������� delegate Ÿ�� ��������Ʈ��(�Ű�����)
    delegate void DelegateTest();
    delegate string DelegateTest2(float x);
    delegate int DelegateTest3(int x, int y);
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //��������Ʈ ���
        //��������Ʈ�� ������ = new ��������Ʈ��(�Լ���);
        DelegateTest dt = new DelegateTest(Attack);

        //�Լ�ó�� ȣ��
        dt();

        //���� ����
        //������ = �Լ���;
        dt = Guard;

        dt();

        //�Ϲ����� �Լ� ȣ���� �ƴ� delegate������ ���� ��ü �Ҵ��ϴ� ����?
        //1. delegate�� �Լ��� �ƴ� Ÿ���̱� ����
        //   �Ű������ε� Ȱ���� �����ϰ�, returnŸ������ ����ִ� �͵� ����


        //2. ��������Ʈ ü��(delegate Chain)
        //delegate�� +=�� ���� �븮�� �Լ��� �� �߰��� �� �ְ�, -=�� ���� �븮�� �Լ��� �����ϴ� �͵� ����
        dt += Attack;
        dt += Attack;
        dt += Attack;
        dt += Guard;
        dt -= Attack;
        dt.Invoke();
        dt();
    }

    void UseDelegate(DelegateTest dt)
    {
        dt();
    }

    DelegateTest Selection(int value)
    {
        if (value == 1)
            return Attack;
        else if (value == 2)
            return Guard;
        else
            return MoveLeft;
    }

    void Attack() => Debug.Log("����");
    void Guard() => Debug.Log("���");
    void MoveLeft() => Debug.Log("�������� �̵�");

}
