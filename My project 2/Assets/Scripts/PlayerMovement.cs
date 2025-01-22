using System;
using UnityEngine;


//�÷��̾��� �̵�(������ٵ�)
//�ݵ�� ������ٵ�������Ʈ�� �䱸(������)
//�ش� ����� ���� �� ��ũ��Ʈ�� ������Ʈ�ν� ����� ��� ������� ������Ʈ�� �䱸
// 1. �ش� ������Ʈ�� ���� ������Ʈ�� ������ ��쿡�� �ڵ����� ������ ����
// 2. �� ��ũ��Ʈ�� ����� ���¶�� �� ������Ʈ�� ����� ������Ʈ�� ������ �� ����
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 2.0f; //�Ҽ����� ���� ���� �������� f��ȣ�� ���
    //�Ҽ��� �� 6�ڸ����� ��Ȯ�ϰ� ���

    public double jump_force = 3.5; //double�� �Ǽ��� ǥ���ϴ� �ڷ����̸� �� ��쿡�� f�� ������ ����
    //�Ҽ��� �� 15�ڸ����� ��Ȯ�ϰ� ���

    public bool isJump = false;

    private Rigidbody2D rigid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        //GetComponent<T>
        //�ش� ������Ʈ�� ���� ������ ���
        //T�κп��� ������Ʈ�� ���¸� �ۼ�
        //������Ʈ�� ���°� �ٸ��ٸ� ���� �߻�
        //�ش� �����Ͱ� �������� ���� ����� null�� ��ȯ�ϰ� ��
        
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
        float y = Input.GetAxisRaw("Vertical");
        //GetAxisRaw("Ű �̸�");�� ��ǲ�Ŵ����� Ű�� �����鼭 Ŭ���� ���� -1, 0, 1�� ��ġ�� ���� ����

        //Horizontal : �����̵� a,dŰ�� Ű������ ����,������ Ű
        //Vertical : ���� �̵� w,sŰ�� Ű������ ��, �Ʒ� Ű

        //���� �ڵ带 ���� ������ ������ ���
        Vector3 velocity = new Vector3(x, y, 0) * speed * Time.deltaTime;
        //�ӷ� = ���� * �ӵ�

        transform.position += velocity;
    }

    private void Jump()
    {
        //����ڰ� Ű���� SpaceŰ�� �Է��Ѵٸ�
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (!isJump) // �������°� �ƴѰ��
            {
                isJump = true; // �������·� ����
                rigid.AddForce(Vector3.up * (float)jump_force, ForceMode2D.Impulse);
                //type casting(Ÿ�� ĳ����)
                //(Ÿ���̸�)���� �� ���� �ش� ������ ������ Ÿ������ ���� ����
                //��, ĳ������ ������ ���������� ����
                //�ַ� int -> float ���� ���� ����
                //������ Ÿ���� ���� ȣȯ���� �ʴ� ����� ��� �Ұ�
            }
            


        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            Debug.Log("����!!!");

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        //�浹ü�� ���ӿ�����Ʈ�� ���̾ 7�� ������ �� ũ�Ⱑ ���ٸ�
        if(collision.gameObject.layer == 7)
        {
            isJump = false;
        }
        Debug.Log("���� ��ҽ��ϴ�!");
    }
}
