using System;
using System.Collections.Generic;
using UnityEngine;


//풀(웅덩이)
//오브젝트를 풀에 만들어두고, 필요할 때마다 풀 안에 있는 객체를 꺼내서 사용하는 방식
//매번 실시간으로 파괴하고 생성하는 것 보다 CPU의 부담을 줄일 수 있음
//대신 미리 할당해두는 방식이기 때문에 메모리를 희생해서 성능을 높이는 방식

//풀에 대한 작업 시 필요한 정보들을 보관하고 있는 인터페이스
public interface IPool
{
    //Property
    Transform parent { get; set; }
    Queue<GameObject> pool { get; set; } // FIFO(First In First Out)

    //Function
    //default parameter : 값을 따로 넣지 않았을 경우 지정한 값으로 자동 처리됨
    // ex) var go = GetGameObject();
    // ex) var go = GetGameObject(action);

    //몬스터를 가져오는 기능
    GameObject GetGameObject(Action<GameObject> action = null);

    //몬스터를 반납하는 기능
    void ObjectReturn(GameObject ob, Action<GameObject> action = null);

}

public class ObjectPool : IPool
{
    public Transform parent { get; set; }
    public Queue<GameObject> pool { get; set; } = new Queue<GameObject>();

    public GameObject GetGameObject(Action<GameObject> action = null)
    {
        var obj = pool.Dequeue(); // 풀에 있는 값 하나 빼오기

        obj.SetActive(true); // 오브젝트 활성화 진행

        //액션으로 전달 받은 값이 있다면
        if(action != null)
        {
            //전달받은 액션을 실행한다
            //?는 null에 대한 설정(현재는 위에서 null체크를 하고 들어오기때문에 꼭 넣을 필요는 없다)
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
        //해당 키가 없다면 추가를 진행
        if(!pool_dict.ContainsKey(path))
        {
            Add(path);
        }

        //큐에 없는 경우 큐 추가
        if (pool_dict[path].pool.Count <= 0)
        {
            AddQ(path);
        }

        //딕셔너리명[키] => 값;
        return pool_dict[path];
    }

    public GameObject Add(string path)
    {
        //전달받은 이름으로 풀 오브젝트 생성
        var obj = new GameObject(path + "Pool");
        
        //오브젝트 풀 생성
        ObjectPool object_pool = new ObjectPool();

        //경로와 오브젝트 풀을 딕셔너리에 저장
        pool_dict.Add(path, object_pool);

        //트랜스폼 설정
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
