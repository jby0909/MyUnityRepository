using UnityEngine;
//유니티의 디자인 패턴 코드 : Singleton

//공통적으로 사용되는 데이터를 하나의 객체(인스턴스)로 돌려쓰겠다

public class Tester : MonoBehaviour
{
    int point = 0;
    private void Start()
    {
        point = Singleton.Instance.point; //싱글톤에 있는 프로퍼티
        Singleton.GetInstance().PointPluss(); //또는 메소드를 통해 클래스 내부의 객체에 접근해서 객체가 가지고 있는 정보를 사용할 수 있음

        //싱글톤 패턴의 장점은 별도로 가져올 필요 없이 바로 그 기능을 사용할 수 있음
        //대신 싱글톤 패턴으로 설계한 인스턴스가 너무 많은 데이터를 공유하는 경우라면 수정이 어렵고 테스트도 까다로워짐
    }
}


public class Singleton : MonoBehaviour
{
    //1. 인스턴스 이면서 전역으로 접근할 수 있게 설계
    private static Singleton _instance;

    //2. 클래스 내부에 표현할 값을 설계
    public int point;

    public void PointPluss()
    {
        point++;
    }

    public void ViewPoint()
    {
        Debug.Log("현재 포인트 : " + point);
    }

    //메소드를 통해서 전달
    public static Singleton GetInstance()
    {
        //현재 값이 비어있다면
        if(_instance == null)
        {
            //새롭게 할당
            _instance = new Singleton();

        }
        //일반적인 경우라면 현재의 인스턴스를 return
        return _instance;
    }

    //프로퍼티로 설계하기
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
