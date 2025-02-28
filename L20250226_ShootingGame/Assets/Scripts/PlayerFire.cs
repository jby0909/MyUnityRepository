using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory; // �Ѿ� ������
    public GameObject firePosition; //�� �߻� ��ġ

    #region ObjectPool
    public int poolSize = 10;

    GameObject[] bulletObjectPool;

    private void Start()
    {
        //1.������ ũ�⸸ŭ Ǯ�� ������Ʈ ����
        bulletObjectPool = new GameObject[poolSize];

        //2.����ŭ �ݺ��� �Ѿ� ����
        for(int i = 0; i < poolSize; i++)
        {
            //�Ѿ� ����
            var bullet = Instantiate(bulletFactory);
            //Ǯ�� ���
            bulletObjectPool[i] = bullet;
            //��Ȱ��ȭ(�ʿ��� �� Ȱ��ȭ)
            bullet.SetActive(false);

        }
    }

    #endregion

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Fire1 : left Ctrl Ű
        {
            for (int i = 0; i < poolSize; i++)
            {
                var bullet = bulletObjectPool[i];

                if(bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    //�Ѿ� ��ġ ����
                    bullet.transform.position = firePosition.transform.position;
                    break;
                }

            }
            
        }

    }
}
