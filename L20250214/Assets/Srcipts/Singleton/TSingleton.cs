using UnityEngine;

// T Singleton
// <T> �κп� Ÿ���� �־ �ش� ���·� ����� �ִ� �̱���

//1. <T>�� ����ڰ� Ÿ���� ���� ��ġ
//2. where�� �ش� �۾��� ���� ���� ����
// T : MonoBehaviour��� T�� MonoBehaviour�̰ų� �Ǵ� ��ӵ� Ŭ�������� ��
public class TSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            //�ν��Ͻ��� ����ִٸ�
            if (instance == null)
            {
                //���� �� ������ �ش� Ÿ���� ������ �ִ� ������Ʈ�� ã�Ƴ�
                //(T)�� ���� ������ �ش� �������� ���·� �����ϱ� ���ؼ�
                instance = (T)FindAnyObjectByType(typeof(T));

                //������ ���縦 �ߴµ��� ����ִ� ��Ȳ�̶��
                if (instance == null)
                {
                    //�ش� Ÿ���� �̸����� ���� ������Ʈ�� ������
                    //ex) ������� �ϴ� �����Ͱ� GameManager��� �̸��� GameManager�� ������ ��
                    var manager = new GameObject(typeof(T).Name);
                    //�Ŵ����� �ش� Ÿ���� ������Ʈ�� ��������
                    instance = manager.AddComponent<T>();

                }
            }
            return instance;
        }
    }

    //protected ��� �������� ����
    protected void Awake()
    {
        if(instance == null)
        {
            //this�� Ŭ���� �ڽ��� �ǹ�
            //as T�� �ش� ���� T �� ����ϰڴٴ� �ڵ�
            instance = this as T;
            //�ε��ص� �ı�ó�� ���� �ʵ��� ����
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
}
