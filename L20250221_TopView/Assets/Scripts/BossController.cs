using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public int hp;
    public int attack = 2;
    public float speed = 1.0f;
    public float pattern_distance = 2.0f;
    public float attack_distance = 2.0f;

   
    bool isAttack = false;
    public static bool isDead = false;

    GameObject player;
    Animator animator;

    public GameObject[] itemPrefabs;

    public GameObject explosionFactory;

    public GameObject slider;
    Slider hpBar;

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
        hpBar = slider.GetComponent<Slider>();
        hp = 10;
        hpBar.value = hp;
        hpBar.maxValue = hp;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (player != null)
        {
            //플레이어와의 거리를 측정
            float distance = Vector2.Distance(transform.position, player.transform.position);



            current_time += Time.deltaTime;
            //일정 시간이 지나면
            if (current_time > check_time && current_time <= check_time + 1.0f)
            {
                //공격하기(공격을 아직 안했을때)
                if (!isAttack)
                {
                    Attack(distance);
                    isAttack = true;
                }
                rbody.linearVelocity = Vector2.zero;
                return;
            }
            else if (current_time > check_time + 1.0f)
            {
                isAttack = false;
                current_time = 0;
            }


            ////플레이어 거리 멀어지면 다시 멈춤
            //if (distance > pattern_distance)
            //{
            //    isActive = false;
            //    rbody.linearVelocity = Vector2.zero;
            //}

            float radian = Util.GetAngleFromTo(transform.position, player.transform.position);


            current = AnimType.BossMove;
            h = Mathf.Cos(radian) * speed;
            v = Mathf.Sin(radian) * speed;
        }
        else 
        {
            
            rbody.linearVelocity = Vector2.zero;
        }


    }




    private void FixedUpdate()
    {
        //활성화 상태이면서 체력이 남아있을 경우
        if ( hp > 0)
        {
            //계산한 좌표로 설정
            rbody.linearVelocity = new Vector2(h, v);

            //애니메이션 달라지면 변경 후 플레이 진행
            if (current != previous)
            {
                previous = current;
                animator.Play(Enum.GetName(typeof(AnimType), current));

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            hp--;
            hpBar.value = hp;

            if (hp <= 0)
            {
                //더이상의 충돌이 발생하지 않음
                GetComponent<CircleCollider2D>().enabled = false;

                //속력이 0이 됨
                rbody.linearVelocity = Vector2.zero;

                //죽음에 대한 애니메이션 처리
                animator.Play(Enum.GetName(typeof(AnimType), AnimType.BossDead));



                //오브젝트 파괴 -> SetActive(false)로 수정
                Invoke("DeadBoss", 1.0f);

                //아이템 드랍
                for (int i = 0; i < itemPrefabs.Length; i++)
                {
                    Instantiate(itemPrefabs[i], transform.position + new Vector3(UnityEngine.Random.Range(-1, 2), UnityEngine.Random.Range(-1, 2), 0), Quaternion.identity);
                }
            }
        }
    }

    void DeadBoss()
    {
        isDead = true;
        gameObject.SetActive(false);
    }


    void Attack(float distance)
    {
        //공격애니메이션
        current = AnimType.BossAttack;

        //공격 범위 효과
        GameObject[] explosion = new GameObject[8];
        float degree = 0;
        for(int i = 0; i < explosion.Length; i++)
        {
            explosion[i] = Instantiate(explosionFactory);
            explosion[i].transform.position = new Vector3(transform.position.x + Mathf.Cos(degree) * attack_distance, transform.position.y + Mathf.Sin(degree) * attack_distance, transform.position.z);
            degree += 45.0f;
        }
        
       
        
        //공격범위 내에 플레이어가 있을 경우 플레이어에게 데미지를 준다
        
        if(distance <= attack_distance)
        {
            player.GetComponent<PlayerController>().GetDamage(gameObject, attack);
        }
    }

   


}
