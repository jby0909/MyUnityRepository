using System;
using System.Collections;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int hp = 10;
    public int attack = 2;
    public float speed = 3.0f;
    public float pattern_distance = 3.0f;
    public int monster_count = 3; //�ӽ÷� ����, ���߿� ������������ ���� �� ���Ϸ� �ޱ�

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
        //�÷��̾� ������ ����X -> ���߿� �ܺο��� �����ϴ� ������ �����ҰͰ���
        if (player == null)
        {
            return;
        }

        ////���� ���� 0�� �Ǿ��� �� -> �̺κе� ���߿� �ܺο��� �����ϴ°����� �����ҰŰ���
        //if(monster_count == 0)
        //{

        //}
        

        current_time += Time.deltaTime;
        if(current_time >= check_time && current_time < check_time * 2)
        {
            Debug.Log("���� �����̱�");
            transform.position = new Vector3(transform.position.x,
                transform.position.y + speed * Time.deltaTime, transform.position.z);
            //transform.position += Vector3.up * speed * Time.deltaTime;
            current = AnimType.BossMove;
        }
        else if(current_time >= check_time * 2 && current_time < check_time * 3)
        {
            Debug.Log("���������� �����̱�");
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,
                transform.position.y, transform.position.z);
            //transform.position += Vector3.right * speed * Time.deltaTime;
            current = AnimType.BossMove;
        }
        else if(current_time >= check_time * 3 && current_time < check_time * 4)
        {
            Debug.Log("���߱�");
            transform.position += Vector3.zero;
            current = AnimType.BossIdle;
        }
        else if(current_time >= check_time * 4 && current_time < check_time * 5)
        {
            Debug.Log("�Ʒ��� �����̱�");
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
            Debug.Log("�������� �����̱�");
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime,
                transform.position.y, transform.position.z);
            //transform.position += Vector3.left * speed * Time.deltaTime;
            current = AnimType.BossMove;
        }

    }

    

    private void FixedUpdate()
    {
        
        //�ִϸ��̼� �޶����� ���� �� �÷��� ����
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
                //���̻��� �浹�� �߻����� ����
                GetComponent<CircleCollider2D>().enabled = false;

                //�ӷ��� 0�� ��
                

                //������ ���� �ִϸ��̼� ó��
                var animator = GetComponent<Animator>();
                animator.Play(Enum.GetName(typeof(AnimType), AnimType.BossDead));

                //������Ʈ �ı�
                Destroy(gameObject, 0.5f);
            }
        }
    }

    void Attack()
    {
        //���ݾִϸ��̼�
        current = AnimType.BossAttack;
        //���Ϲ��� ���� �÷��̾ ���� ��� �÷��̾�� �������� �ش�
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance <= pattern_distance)
        {
            player.GetComponent<PlayerController>().GetDamage(gameObject, attack);
        }
    }


}
