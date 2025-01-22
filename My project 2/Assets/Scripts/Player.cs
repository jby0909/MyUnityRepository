using System;
using UnityEngine;


//플레이어의 이동(리지드바디)
//반드시 리지드바디컴포넌트를 요구(강제성)
//해당 기능을 통해 이 스크립트를 컴포넌트로써 사용할 경우 적어놓은 컴포넌트를 요구
// 1. 해당 컴포넌트가 없는 오브젝트에 연결할 경우에는 자동으로 연결을 진행
// 2. 이 스크립트가 연결된 상태라면 그 오브젝트는 대상의 컴포넌트를 제거할 수 없음
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    int score = 0;
    public float speed = 3.0f;

    public float jump_force = 3;

    public bool isJump = false;

    private Rigidbody2D rigid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //GetComponent<T>
        //해당 컴포넌트의 값을 얻어오는 기능
        //T부분에는 컴포넌트의 형태를 작성
        //컴포넌트의 형태가 다르다면 오류 발생
        //해당 데이터가 존재하지 않을 경우라면 null을 반환하게 됨

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        
        //GetAxisRaw("키 이름");은 인풋매니저의 키를 얻어오면서 클릭에 따라 -1, 0, 1의 수치로 값을 얻어옴

        //Horizontal : 수평이동 a,d키나 키보드의 왼쪽,오른쪽 키
        //Vertical : 수직 이동 w,s키나 키보드의 위, 아래 키

        //위의 코드를 통해 움직일 방향을 계산
        Vector3 velocity = new Vector3(x, 0, 0) * speed * Time.deltaTime;
        //속력 = 방향 * 속도

        transform.position += velocity;
    }

    private void Jump()
    {
        //사용자가 키보드 Space키를 입력한다면
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!isJump) // 점프상태가 아닌경우
            {
                isJump = true; // 점프상태로 변경
                rigid.AddForce(Vector3.up * jump_force, ForceMode2D.Impulse);
                //type casting(타입 캐스팅)
                //(타입이름)변수 를 통해 해당 변수를 설정한 타입으로 변경 가능
                //단, 캐스팅이 가능한 범위에서만 진행
                //주로 int -> float 같은 경우는 가능
                //데이터 타입이 서로 호환되지 않는 경우라면 사용 불가
            }



        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            score++;
            collision.gameObject.SetActive(false);

        }

        if (collision.gameObject.tag == "Finish")
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //충돌체의 게임오브젝트의 레이어가 7과 비교했을 때 크기가 같다면
        if (collision.gameObject.layer == 7 || collision.gameObject.tag == "box")
        {
            isJump = false;
        }
        Debug.Log("땅을 밟았습니다!");
    }
}
