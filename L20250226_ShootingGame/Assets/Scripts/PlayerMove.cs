using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float speed = 5.0f;


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);

        //transform.Translate() -> 이걸로 이동로직 구현해도 됨. 우리는 보통 position을 직접 조작해서 했으므로 아래방법으로 구현함
        transform.position += dir * speed * Time.deltaTime;

        

        //물체의 이동 공식
        //(등속운동)
        // P = P0 + VT
        // 미래의 위치 = 현재의 위치 + 속도*시간

        //(등가속도 운동)
        //V = V0 + AT
        //속도 = 현재속도 + 가속도*시간

        //(가속도)
        //F = ma
        //힘 = 질량*가속도
    }
}
