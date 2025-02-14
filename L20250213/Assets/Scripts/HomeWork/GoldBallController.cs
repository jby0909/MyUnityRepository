using UnityEngine;

public class GoldBallController : MonoBehaviour
{
    public GameObject goldBall;
    void Start()
    {
        //if(퀘스트 수락했을 시에) << 그럼start() 가 아닌 다른곳에 함수로 빼놓고 이벤트 발생 시 실행되도록 바꿔야할듯
        for(int i = 0; i < 10; i++)
        {
            //z : -9 ~ 16 ,x : -11 ~ 9  
            float randx = Random.Range(-11, 10);
            float randz = Random.Range(-9, 17);
            Instantiate(goldBall, new Vector3(randx, 0.25f, randz), Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
