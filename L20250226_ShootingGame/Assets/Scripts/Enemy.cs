using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 dir;

    public GameObject explosionFactory;

    //OnEnable�� ����Ƽ���� �������ִ� Ȱ��ȭ �ܰ迡 ȣ��Ǵ� �Լ�(Ȱ��ȭ ų������ ȣ��ȴ�)
    private void OnEnable()
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
        ScoreManager.Instance.Score++;

        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        //�ε��� ��ü�� �̸��� Bullet�� ���Եȴٸ�(������Ʈ Ǯ�� ������� �̸��� Bullet(Clone)�̷����̱� ������)
        if(collision.gameObject.name.Contains("Bullet"))
        {
            Debug.Log("�Ѿ˰� �浹");
            //�ش� �浹ü�� ��Ȱ��ȭ ó��
            collision.gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("�÷��̾�� �浹");
            Destroy(collision.gameObject);
        }
        Debug.Log("�ڱ��ڽ� �������");
        gameObject.SetActive(false); // ���� ��Ȱ��ȭ
    }

}
