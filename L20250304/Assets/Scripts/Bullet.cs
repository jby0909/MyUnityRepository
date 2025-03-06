using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float movespeed = 10.0f;

    private void Awake()
    {
        //C# ������ �÷���(�ٷ� ������ ����)
        Destroy(gameObject, 3.0f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * movespeed * Time.deltaTime, Space.Self);
        //��������
        //transform.Translate(transform.up * movespeed * Time.deltaTime, Space.World);
    }
}
