using System;
using UnityEngine;




[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    //애니메이션 이름으로 설정
    public enum ANIME_STATE
    {
        PlayerIDLE,
        PlayerClear,
        PlayerGameOver,
        PlayerRun,
        PlayerJump
    }

    Animator animator;
    public string current = " "; //현재 진행중인 애니메이션
    public string previous = " "; //기존에 진행 중이던 애니메이션


    Rigidbody2D rbody;
    float axisH = 0.0F;
    public float speed = 3.0f;

    public float jump = 9.0f;
    public LayerMask groundLayer;
    bool goJump = false;
    bool onGround = false;

    public static string state = "playing"; // 현재의 상태(플레이 중)

    
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        state = "playing";

    }


    void Update()
    {
        if(state != "playing")
        {
            return;
        }

        axisH = Input.GetAxisRaw("Horizontal"); //수평 이동

        if(axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if(axisH < 0.0F)
        {
            transform.localScale = new Vector2(-1, 1);
            //벡터가 -로 잡히게 되면 좌우 반전
            //이 방법 말고 좌우반전을 하고 싶다면 Sprite Renderer의 Flip의 X를 체크/해제 하는 방식으로 구현 할 수 있음.
            
            
        }

        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (state != "playing")
        {
            return;
        }

        //지정한 두 점을 연결하는 가상의 선에 게임 오브젝트가 접촉하는지를 조사해 true 또는 false로 return해주는 함수
        onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);
        //up은 Vector기준 (0, 1, 0)
        //(플레이어의 현재 pivot은 bottom)


        //지면 위에 있거나 속도가 0이 아닌 경우
        if(onGround || axisH != 0)
        {
            rbody.linearVelocity = new Vector2(speed * axisH, rbody.linearVelocityY);
        }

        //지면 위에 있는 상태에서 점프 키가 눌린 상황
        if(onGround && goJump)
        {
            Vector2 jumpPw = new Vector2(0, jump); //플레이어가 가진 점프 수치만큼 백터 설계
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); //해당 위치로 힘을 가한다
            goJump = false; // 점프가 완료되었으니 다시 플래그 끄기
        }


        //땅에 닿아있는데
        if(onGround)
        {
            //속도가 0일경우
            if(axisH == 0)
            {
                //Enum.GetName(typeof(enum명), 값);
                //해당 enum에 있는 그 값의 이름을 얻어오는 기능
                current = Enum.GetName(typeof(ANIME_STATE), 0); //PlayerIDLE
            }
            else 
            {
                current = Enum.GetName(typeof(ANIME_STATE), 3); //PlayerRun
            }
        }
        else
        {
            current = Enum.GetName(typeof(ANIME_STATE), 4); //PlayerJump
        }

        //현재의 모션이 이전의 모션과 다른 경우(애니메이션이 바뀐 경우)
        if(current != previous)
        {
            previous = current; // 이전 동작에 대한 세이브
            animator.Play(current); // 현재의 모션 플레이
        }

    }

    private void Jump()
    {
        goJump = true; //플래그 키는 작업
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if(collision.gameObject.tag == "Dead")
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        animator.Play(Enum.GetName(typeof(ANIME_STATE), 2));
        state = "gameover";
        GameStop();
        //현재 플레이어가 가지고 있는 콜라이더의 활성화를 비활성화로 설정(더이상의 충돌이 발생하지 않도록)
        GetComponent<CapsuleCollider2D>().enabled = false;
        //위로 살짝 뛰어오르는 연출
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    private void GameStop()
    {
        //var rbody = GetComponent<Rigidbody2D>();
        rbody.linearVelocity = new Vector2(0, 0); // 속력을 0으로 만들어서 움직이지 못하게
    }

    private void Goal()
    {
        animator.Play(Enum.GetName(typeof(ANIME_STATE), 1));
        state = "gameclear";
        GameStop();
    }
}
