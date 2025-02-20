using System;
using UnityEngine;




[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    //�ִϸ��̼� �̸����� ����
    public enum ANIME_STATE
    {
        PlayerIDLE,
        PlayerClear,
        PlayerGameOver,
        PlayerRun,
        PlayerJump
    }

    Animator animator;
    public string current = " "; //���� �������� �ִϸ��̼�
    public string previous = " "; //������ ���� ���̴� �ִϸ��̼�


    Rigidbody2D rbody;
    float axisH = 0.0F;
    public float speed = 3.0f;

    public float jump = 9.0f;
    public LayerMask groundLayer;
    bool goJump = false;
    bool onGround = false;

    public static string state = "playing"; // ������ ����(�÷��� ��)

    
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

        axisH = Input.GetAxisRaw("Horizontal"); //���� �̵�

        if(axisH > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if(axisH < 0.0F)
        {
            transform.localScale = new Vector2(-1, 1);
            //���Ͱ� -�� ������ �Ǹ� �¿� ����
            //�� ��� ���� �¿������ �ϰ� �ʹٸ� Sprite Renderer�� Flip�� X�� üũ/���� �ϴ� ������� ���� �� �� ����.
            
            
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

        //������ �� ���� �����ϴ� ������ ���� ���� ������Ʈ�� �����ϴ����� ������ true �Ǵ� false�� return���ִ� �Լ�
        onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);
        //up�� Vector���� (0, 1, 0)
        //(�÷��̾��� ���� pivot�� bottom)


        //���� ���� �ְų� �ӵ��� 0�� �ƴ� ���
        if(onGround || axisH != 0)
        {
            rbody.linearVelocity = new Vector2(speed * axisH, rbody.linearVelocityY);
        }

        //���� ���� �ִ� ���¿��� ���� Ű�� ���� ��Ȳ
        if(onGround && goJump)
        {
            Vector2 jumpPw = new Vector2(0, jump); //�÷��̾ ���� ���� ��ġ��ŭ ���� ����
            rbody.AddForce(jumpPw, ForceMode2D.Impulse); //�ش� ��ġ�� ���� ���Ѵ�
            goJump = false; // ������ �Ϸ�Ǿ����� �ٽ� �÷��� ����
        }


        //���� ����ִµ�
        if(onGround)
        {
            //�ӵ��� 0�ϰ��
            if(axisH == 0)
            {
                //Enum.GetName(typeof(enum��), ��);
                //�ش� enum�� �ִ� �� ���� �̸��� ������ ���
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

        //������ ����� ������ ��ǰ� �ٸ� ���(�ִϸ��̼��� �ٲ� ���)
        if(current != previous)
        {
            previous = current; // ���� ���ۿ� ���� ���̺�
            animator.Play(current); // ������ ��� �÷���
        }

    }

    private void Jump()
    {
        goJump = true; //�÷��� Ű�� �۾�
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
        //���� �÷��̾ ������ �ִ� �ݶ��̴��� Ȱ��ȭ�� ��Ȱ��ȭ�� ����(���̻��� �浹�� �߻����� �ʵ���)
        GetComponent<CapsuleCollider2D>().enabled = false;
        //���� ��¦ �پ������ ����
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
    }

    private void GameStop()
    {
        //var rbody = GetComponent<Rigidbody2D>();
        rbody.linearVelocity = new Vector2(0, 0); // �ӷ��� 0���� ���� �������� ���ϰ�
    }

    private void Goal()
    {
        animator.Play(Enum.GetName(typeof(ANIME_STATE), 1));
        state = "gameclear";
        GameStop();
    }
}
