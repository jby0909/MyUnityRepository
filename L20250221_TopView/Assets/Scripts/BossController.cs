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
            //�÷��̾���� �Ÿ��� ����
            float distance = Vector2.Distance(transform.position, player.transform.position);



            current_time += Time.deltaTime;
            //���� �ð��� ������
            if (current_time > check_time && current_time <= check_time + 1.0f)
            {
                //�����ϱ�(������ ���� ��������)
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


            ////�÷��̾� �Ÿ� �־����� �ٽ� ����
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
        //Ȱ��ȭ �����̸鼭 ü���� �������� ���
        if ( hp > 0)
        {
            //����� ��ǥ�� ����
            rbody.linearVelocity = new Vector2(h, v);

            //�ִϸ��̼� �޶����� ���� �� �÷��� ����
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
                //���̻��� �浹�� �߻����� ����
                GetComponent<CircleCollider2D>().enabled = false;

                //�ӷ��� 0�� ��
                rbody.linearVelocity = Vector2.zero;

                //������ ���� �ִϸ��̼� ó��
                animator.Play(Enum.GetName(typeof(AnimType), AnimType.BossDead));



                //������Ʈ �ı� -> SetActive(false)�� ����
                Invoke("DeadBoss", 1.0f);

                //������ ���
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
        //���ݾִϸ��̼�
        current = AnimType.BossAttack;

        //���� ���� ȿ��
        GameObject[] explosion = new GameObject[8];
        float degree = 0;
        for(int i = 0; i < explosion.Length; i++)
        {
            explosion[i] = Instantiate(explosionFactory);
            explosion[i].transform.position = new Vector3(transform.position.x + Mathf.Cos(degree) * attack_distance, transform.position.y + Mathf.Sin(degree) * attack_distance, transform.position.z);
            degree += 45.0f;
        }
        
       
        
        //���ݹ��� ���� �÷��̾ ���� ��� �÷��̾�� �������� �ش�
        
        if(distance <= attack_distance)
        {
            player.GetComponent<PlayerController>().GetDamage(gameObject, attack);
        }
    }

   


}
