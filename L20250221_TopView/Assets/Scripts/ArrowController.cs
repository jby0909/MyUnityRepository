using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float remove = 2.0f;

    void Start()
    {
        Destroy(gameObject, remove);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        //�浹ü�� Ʈ���� ���� ȭ���� �θ� Ʈ���� ���� ��
        transform.SetParent(collision.transform);

        //���� ���Ŀ��� �浹 ������ ����
        GetComponent<CircleCollider2D>().enabled = false;

        //���� �ùķ��̼ǵ� ��Ȱ��
        GetComponent<Rigidbody2D>().simulated = false;
    }
}
