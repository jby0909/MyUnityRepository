using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 30.0f;
    Vector3 vec;
    [SerializeField]
    GameObject prefab;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            vec = new Vector3(Time.deltaTime * speed, 0, 0);
            transform.position += vec;
           
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            vec = new Vector3(Time.deltaTime * speed, 0, 0);

            transform.position -= vec;
           
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + 1f, 0),Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            Destroy(gameObject);
        }
    }
}
