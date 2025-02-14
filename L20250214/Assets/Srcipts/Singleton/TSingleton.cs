using UnityEngine;

// T Singleton
// <T> 부분에 타입을 넣어서 해당 형태로 만들어 주는 싱글톤

//1. <T>는 사용자가 타입을 적는 위치
//2. where는 해당 작업에 대한 제약 조건
// T : MonoBehaviour라면 T는 MonoBehaviour이거나 또는 상속된 클래스여야 함
public class TSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            //인스턴스가 비어있다면
            if (instance == null)
            {
                //게임 씬 내에서 해당 타입을 가지고 있는 오브젝트를 찾아냄
                //(T)를 적은 이유는 해당 데이터의 형태로 변형하기 위해서
                instance = (T)FindAnyObjectByType(typeof(T));

                //씬에서 조사를 했는데도 비어있는 상황이라면
                if (instance == null)
                {
                    //해당 타입의 이름으로 게임 오브젝트를 생성함
                    //ex) 만들려고 하는 데이터가 GameManager라면 이름도 GameManager로 지어질 것
                    var manager = new GameObject(typeof(T).Name);
                    //매니저에 해당 타입을 컴포넌트로 연결해줌
                    instance = manager.AddComponent<T>();

                }
            }
            return instance;
        }
    }

    //protected 상속 범위까지 적용
    protected void Awake()
    {
        if(instance == null)
        {
            //this는 클래스 자신을 의미
            //as T는 해당 값을 T 로 취급하겠다는 코드
            instance = this as T;
            //로드해도 파괴처리 되지 않도록 설정
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }
}
