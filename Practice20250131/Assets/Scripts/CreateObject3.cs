using UnityEngine;

public class CreateObject3 : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    private int dummy;
    //����ȭ
    //�����ͳ� ������Ʈ�� ��ǻ�� ȯ�濡 �����ϰ� �籸���� �� �ִ� ����(����)�� ��ȯ�ϴ� ����
    //����Ƽ������ �����ϰ� private������ �����͸� �ν����Ϳ��� ���� �� �ְ� �������ش� ��� ����
    [SerializeField] GameObject sample;
    private void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/table_body");
        //Resource.Load<T>("������ġ/���¸�");
        //T�� �������� ���¸� �����ִ� ��ġ
    }
    private void Update()
    {
        //�Է¹��� Ű�� �����̽��� ���
        //GetKeyDown (Ű 1�� �Է�)
        //GetKeyUp (�Է� �� ���� ���)
        //GetKey(������ �ִ� ����)
        //if���� ������ 0�̸� false, ���� ���� true
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sample = Instantiate(prefab);

            sample.AddComponent<VectorSample>();
            //gameObject.AddComponent<T>
            //������Ʈ�� ������Ʈ ����� �߰��ϴ� ���
            
            //GetComponent<T>
            //������Ʈ�� ������ �ִ� ������Ʈ�� ����� ������ ���
            //��ũ��Ʈ���� �ش� ������Ʈ�� ����� �����ͼ� ����ϰ� ���� ��� ���

        }
    }
}
