using UnityEngine;

public class NewPlayerController : MonoBehaviour
{
    
    float rotateSpeed = 60.0f;
    float moveSpeed = 3.0f;
    void Start()
    {
        
    }

    
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //���⼭ normalized�� �ϴ� ���� : �밢������ ������ �� ���� 1���� Ŀ���� �ӵ��� �� �������⶧���� ��� ���⿡�� �ӵ��� �����ϰ� ���߱� ���ؼ�.
        transform.Translate(new Vector3(h, v, 0).normalized * Time.deltaTime * moveSpeed);
        //transform.eulerAngles += transform.forward * Time.deltaTime * -h * rotateSpeed;
        transform.Rotate(new Vector3(0, 0, -h) * Time.deltaTime * rotateSpeed);
        
        
    }
}
