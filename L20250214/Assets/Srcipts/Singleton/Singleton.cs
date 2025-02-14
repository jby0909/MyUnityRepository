using UnityEngine;
//����Ƽ�� ������ ���� �ڵ� : Singleton

//���������� ���Ǵ� �����͸� �ϳ��� ��ü(�ν��Ͻ�)�� �������ڴ�

public class Tester : MonoBehaviour
{
    int point = 0;
    private void Start()
    {
        point = Singleton.Instance.point; //�̱��濡 �ִ� ������Ƽ
        Singleton.GetInstance().PointPluss(); //�Ǵ� �޼ҵ带 ���� Ŭ���� ������ ��ü�� �����ؼ� ��ü�� ������ �ִ� ������ ����� �� ����

        //�̱��� ������ ������ ������ ������ �ʿ� ���� �ٷ� �� ����� ����� �� ����
        //��� �̱��� �������� ������ �ν��Ͻ��� �ʹ� ���� �����͸� �����ϴ� ����� ������ ��ư� �׽�Ʈ�� ��ٷο���
    }
}


public class Singleton : MonoBehaviour
{
    //1. �ν��Ͻ� �̸鼭 �������� ������ �� �ְ� ����
    private static Singleton _instance;

    //2. Ŭ���� ���ο� ǥ���� ���� ����
    public int point;

    public void PointPluss()
    {
        point++;
    }

    public void ViewPoint()
    {
        Debug.Log("���� ����Ʈ : " + point);
    }

    //�޼ҵ带 ���ؼ� ����
    public static Singleton GetInstance()
    {
        //���� ���� ����ִٸ�
        if(_instance == null)
        {
            //���Ӱ� �Ҵ�
            _instance = new Singleton();

        }
        //�Ϲ����� ����� ������ �ν��Ͻ��� return
        return _instance;
    }

    //������Ƽ�� �����ϱ�
    public static Singleton Instance
    {
        get 
        {
            if(_instance == null)
            {
                _instance = new Singleton();
            }
            return _instance; 
        }
    }
}
