using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float speed = 5.0f;


    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, v, 0);

        //transform.Translate() -> �̰ɷ� �̵����� �����ص� ��. �츮�� ���� position�� ���� �����ؼ� �����Ƿ� �Ʒ�������� ������
        transform.position += dir * speed * Time.deltaTime;

        

        //��ü�� �̵� ����
        //(��ӿ)
        // P = P0 + VT
        // �̷��� ��ġ = ������ ��ġ + �ӵ�*�ð�

        //(��ӵ� �)
        //V = V0 + AT
        //�ӵ� = ����ӵ� + ���ӵ�*�ð�

        //(���ӵ�)
        //F = ma
        //�� = ����*���ӵ�
    }
}
