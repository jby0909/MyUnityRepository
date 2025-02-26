using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; // �Ѿ� ������
    public GameObject firePosition; //�� �߻� ��ġ
    
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Fire1 : left Ctrl Ű
        {
            //�Ѿ� ����
            GameObject bullet = Instantiate(bulletFactory);
            //�Ѿ� ��ġ ����
            bullet.transform.position = firePosition.transform.position;
        }

    }
}
