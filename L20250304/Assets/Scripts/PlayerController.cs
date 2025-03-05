using UnityEngine;

//�Է��̳� �ٸ� �̺�Ʈ�� ó���Ѵ�
//���� ���� ������Ʈ�� �ٸ� ������Ʈ�� ����� ������.
//����� ������Ʈ�� �Ѱ��� �ϸ� �ؾ� �ȴ�.
public class PlayerController : MonoBehaviour
{
    MeshRenderer meshRenderer;

    float moveSpeed = 3.0f;
    float rotationSpeed = 60.0f;
    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //velocity => vector ũ��� ����
        //s = v * t
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        //������ǥ��, ���� ��ǥ��
        //transform.position += transform.up * v * Time.deltaTime * moveSpeed;
        transform.Translate(Vector3.up * v * Time.deltaTime * moveSpeed);
        transform.eulerAngles += transform.forward * -h * Time.deltaTime * rotationSpeed;

        //if(Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
        //}
        //if(Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.position += new Vector3(0, -1, 0) * Time.deltaTime;
        //}

    }
}
