using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float movespeed = 10.0f;

    private void Awake()
    {
        //C# 가비지 컬렉터(바로 지우지 않음)
        Destroy(gameObject, 3.0f);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * movespeed * Time.deltaTime, Space.Self);
        //같은내용
        //transform.Translate(transform.up * movespeed * Time.deltaTime, Space.World);
    }
}
