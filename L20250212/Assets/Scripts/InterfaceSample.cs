using UnityEngine;


//����Ƽ�� �������̽�(interface)
//�������� Ư¡�� ���� ���� ���� �� ȿ����.
//�Լ��� ������Ƽ ���� ���Ǹ� ���� ���� ������ �� �ֵ��� �����ִ� ���
//�������̽��� ��ø� �ϱ� ������, ����ϱ� ���ؼ��� �ݵ�� ����� ���� �籸������ ����.


public interface ICountAble
{
    //�������̽� �������� ���� ������. ex) int a = 0; �̷������� �ν��Ͻ�ȭ�� �ȵ�
    int Count {  get; set; }
    void CountPlus();
}

public interface IUseAble
{
    void Use();
}

public class Item
{

}


//�������̽��� ���ó�� ����� �� ����
//�������̽��� ��� ���� ����� ����
class Potion : Item, ICountAble, IUseAble
{
    private int count;
    private string name;
    public int Count {
        get
        {
            return count; 
        }
        set
        {
            if(value > 99)
            {
                Debug.Log("count�� 99�� �ִ��Դϴ�.");
                count = 99;
            }
            count = value;
        }
    }

    public string Name { get => name; set => name = value; }

    public void CountPlus()
    {
        Count++;
    }

    public void Use()
    {
        Debug.Log($"{name}�� ����߽��ϴ�.");
        Count--;
    }
}


public class InterfaceSample : MonoBehaviour
{
    Potion potion = new Potion();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //�ϼ��� Ŭ���� ����ϱ�
        potion.Count = 99;
        potion.Name = "���� ����";
        potion.CountPlus();
        potion.Use();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
