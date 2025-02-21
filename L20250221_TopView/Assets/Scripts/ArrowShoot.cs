using System;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float speed = 12.0f;
    public float delay = 0.25f;
    public GameObject bowPrefab; //Ȱ
    public GameObject arrowPrefab;

    bool inAttack = false; // ���� ������� Ȯ��
    GameObject bowObject;


    void Start()
    {
        Vector3 pos = transform.position;
        bowObject = Instantiate(bowPrefab, pos, Quaternion.identity);
        //Ȱ ������Ʈ�� �θ� �÷��̾�� ���
        bowObject.transform.SetParent(transform);

    }

    // Update is called once per frame
    void Update()
    {
        //left shift ������ ��
        if(Input.GetButtonDown("Fire3"))
        {
            Attack();
        }

        //rotate bow, order
        float bowZ = -1; //ĳ���ͺ��� �̹����� �տ� ������ ��
        var player_controller = GetComponent<PlayerController>();

        if (player_controller.z > 30 && player_controller.z < 150)
        {
            bowZ = 1;
        }
        bowObject.transform.rotation = Quaternion.Euler(0, 0, player_controller.z);

        bowObject.transform.position = new Vector3(transform.position.x, transform.position.y, bowZ);
    }

    private void Attack()
    {
        //ȭ���� ������ �ְ�, ���� ���°� �ƴ� ���
        if(ItemKeeper.hasArrows > 0 && inAttack == false)
        {
            ItemKeeper.hasArrows--; //ȭ�� �� �� �Ҹ�
            inAttack = true; //���� ���� ��ȯ

            var player_controller = GetComponent<PlayerController>();

            float z = player_controller.z; // ȸ�� ��

            var rotation = Quaternion.Euler(0, 0, z);

            //����� ȸ�� ������ ������Ʈ�� ����
            var arrow_object = Instantiate(arrowPrefab, transform.position, rotation);

            float x = Mathf.Cos(z * Mathf.Deg2Rad);
            float y = Mathf.Sin(z * Mathf.Deg2Rad);

            Vector2 vector = new Vector3(x, y) * speed; //Vector2�� �ᵵ ��� ����

            var rbody = arrow_object.GetComponent<Rigidbody2D>();

            rbody.AddForce(vector, ForceMode2D.Impulse);

            //�߻� �����̸�ŭ ���� ���Ѽ� ���� ��带 ����
            Invoke("AttackChange", delay);

        }
    }

    public void AttackChange() => inAttack = false;
}
