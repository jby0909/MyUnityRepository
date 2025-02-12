using UnityEngine;


//유니티의 인터페이스(interface)
//공통적인 특징에 대한 관리 구현 시 효과적.
//함수나 프로퍼티 등의 정의를 구현 없이 진행할 수 있도록 도와주는 기능
//인터페이스는 명시만 하기 때문에, 사용하기 위해서는 반드시 상속을 통한 재구현으로 진행.


public interface ICountAble
{
    //인터페이스 내에서는 선언만 진행함. ex) int a = 0; 이런식으로 인스턴스화는 안됨
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


//인터페이스는 상속처럼 등록할 수 있음
//인터페이스의 경우 다중 상속이 가능
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
                Debug.Log("count는 99이 최대입니다.");
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
        Debug.Log($"{name}을 사용했습니다.");
        Count--;
    }
}


public class InterfaceSample : MonoBehaviour
{
    Potion potion = new Potion();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //완성된 클래스 사용하기
        potion.Count = 99;
        potion.Name = "빨간 포션";
        potion.CountPlus();
        potion.Use();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
