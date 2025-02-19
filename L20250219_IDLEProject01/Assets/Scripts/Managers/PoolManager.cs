using System;
using System.Collections.Generic;
using UnityEngine;


//Ǯ(������)
//������Ʈ�� Ǯ�� �����ΰ�, �ʿ��� ������ Ǯ �ȿ� �ִ� ��ü�� ������ ����ϴ� ���
//�Ź� �ǽð����� �ı��ϰ� �����ϴ� �� ���� CPU�� �δ��� ���� �� ����
//��� �̸� �Ҵ��صδ� ����̱� ������ �޸𸮸� ����ؼ� ������ ���̴� ���

//Ǯ�� ���� �۾� �� �ʿ��� �������� �����ϰ� �ִ� �������̽�
public interface IPool
{
    //Property
    Transform parent { get; set; }
    Queue<GameObject> pool { get; set; } // FIFO(First In First Out)

    //Function
    //default parameter : ���� ���� ���� �ʾ��� ��� ������ ������ �ڵ� ó����
    // ex) var go = GetGameObject();
    // ex) var go = GetGameObject(action);

    //���͸� �������� ���
    GameObject GetGameObject(Action<GameObject> action = null);

    //���͸� �ݳ��ϴ� ���
    void ObjectReturn(GameObject ob, Action<GameObject> action = null);

}

public class ObjectPool : IPool
{
    public Transform parent { get; set; }
    public Queue<GameObject> pool { get; set; } = new Queue<GameObject>();

    public GameObject GetGameObject(Action<GameObject> action = null)
    {
        var obj = pool.Dequeue(); // Ǯ�� �ִ� �� �ϳ� ������

        obj.SetActive(true); // ������Ʈ Ȱ��ȭ ����

        //�׼����� ���� ���� ���� �ִٸ�
        if(action != null)
        {
            //���޹��� �׼��� �����Ѵ�
            //?�� null�� ���� ����(����� ������ nullüũ�� �ϰ� �����⶧���� �� ���� �ʿ�� ����)
            action?.Invoke(obj);
        }
        return obj;
    }

    public void ObjectReturn(GameObject ob, Action<GameObject> action = null)
    {
        pool.Enqueue(ob);
        ob.transform.parent = parent;
        ob.SetActive(false);

        if(action != null)
        {
            action?.Invoke(ob);
        }
    }
}

public class PoolManager 
{
    //Key : string
    //Value : IPool
    public Dictionary<string, IPool> pool_dict = new Dictionary<string, IPool>();

    public IPool PoolObject(string path)
    {
        //�ش� Ű�� ���ٸ� �߰��� ����
        if(!pool_dict.ContainsKey(path))
        {
            Add(path);
        }

        //ť�� ���� ��� ť �߰�
        if (pool_dict[path].pool.Count <= 0)
        {
            AddQ(path);
        }

        //��ųʸ���[Ű] => ��;
        return pool_dict[path];
    }

    public GameObject Add(string path)
    {
        //���޹��� �̸����� Ǯ ������Ʈ ����
        var obj = new GameObject(path + "Pool");
        
        //������Ʈ Ǯ ����
        ObjectPool object_pool = new ObjectPool();

        //��ο� ������Ʈ Ǯ�� ��ųʸ��� ����
        pool_dict.Add(path, object_pool);

        //Ʈ������ ����
        object_pool.parent = obj.transform;

        return obj;
    }

    public void AddQ(string path)
    {
        var go = Manager.instance.CreateFromPath(path);
        go.transform.parent = pool_dict[path].parent;
        pool_dict[path].ObjectReturn(go);
    }
}
