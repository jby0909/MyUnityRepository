using System;
using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int hp = 10;
    public int attack = 2;
    public float speed = 3.0f;
    public float pattern_distance = 3.0f;
    public int monster_count = 3; //임시로 정함, 나중에 스테이지마다 몬스터 수 파일로 받기

    GameObject player;
    Animator animator;

    Rigidbody2D rbody;
    float h, v;
    enum AnimType
    {
        None,
        BossIdle,
        BossAttack,
        BossMove,
        BossDead
    }

    AnimType current = AnimType.None;
    AnimType previous = AnimType.None;
    

    float current_time = 0;
    float check_time = 3.0f;
   
    void Start()
    {
        
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        rbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //플레이어 없으면 동작X -> 나중에 외부에서 생성하는 곳에서 관리할것같음
        if (player == null)
        {
            return;
        }

        ////몬스터 수가 0이 되었을 때 -> 이부분도 나중에 외부에서 생성하는곳에서 관리할거같음
        //if(monster_count == 0)
        //{

        //}
        

        current_time += Time.deltaTime;
        if(current_time >= check_time && current_time < check_time * 2)
        {
            Debug.Log("위로 움직이기");
            transform.position = new Vector3(transform.position.x,
                transform.position.y + speed * Time.deltaTime, transform.position.z);
            //transform.position += Vector3.up * speed * Time.deltaTime;
            current = AnimType.BossMove;
        }
        else if(current_time >= check_time * 2 && current_time < check_time * 3)
        {
            Debug.Log("오른쪽으로 움직이기");
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,
                transform.position.y, transform.position.z);
            //transform.position += Vector3.right * speed * Time.deltaTime;
            current = AnimType.BossMove;
        }
        else if(current_time >= check_time * 3 && current_time < check_time * 4)
        {
            Debug.Log("멈추기");
            transform.position += Vector3.zero;
            current = AnimType.BossIdle;
        }
        else if(current_time >= check_time * 4 && current_time < check_time * 5)
        {
            Debug.Log("아래로 움직이기");
            transform.position = new Vector3(transform.position.x,
                transform.position.y - speed * Time.deltaTime, transform.position.z);
            //transform.position += Vector3.down * speed * Time.deltaTime;
            current = AnimType.BossMove;
            
        }
        else if(current_time >= check_time * 5)
        {
            Attack(); 
            current_time = 0;
        }
        else
        {
            Debug.Log("왼쪽으로 움직이기");
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,
                transform.position.y, transform.position.z);
            //transform.position += Vector3.left * speed * Time.deltaTime;
            current = AnimType.BossMove;
        }

    }

    

    private void FixedUpdate()
    {
        
        //애니메이션 달라지면 변경 후 플레이 진행
        if (current != previous)
        {
            previous = current;
            
            animator.Play(Enum.GetName(typeof(AnimType),current));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            hp--;

            if (hp <= 0)
            {
                //더이상의 충돌이 발생하지 않음
                GetComponent<CircleCollider2D>().enabled = false;

                //속력이 0이 됨
                

                //죽음에 대한 애니메이션 처리
                var animator = GetComponent<Animator>();
                animator.Play(Enum.GetName(typeof(AnimType), AnimType.BossDead));

                //오브젝트 파괴
                Destroy(gameObject, 0.5f);
            }
        }
    }

    void Attack()
    {
        //공격애니메이션
        current = AnimType.BossAttack;
        //패턴범위 내에 플레이어가 있을 경우 플레이어에게 데미지를 준다
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance <= pattern_distance)
        {
            player.GetComponent<PlayerController>().GetDamage(gameObject, attack);
        }
    }


}
