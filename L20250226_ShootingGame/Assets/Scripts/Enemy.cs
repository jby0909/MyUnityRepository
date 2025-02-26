using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 dir;

    public GameObject explosionFactory;

    private void Start()
    {
        //���� ���� ����
        int rand = Random.Range(0, 10); // 0 ~ 9 ���� ������ �ϳ� ������

        //30% Ȯ��
        if(rand < 3)
        {
            var target = GameObject.FindGameObjectWithTag("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize(); // ������ ũ�⸦ 1�� ����
            //���� ����(Vector3.up, Vector3.down, Vector3.left ....)
        }
        else
        {
            dir = Vector3.down;
        }
    }
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }

}
