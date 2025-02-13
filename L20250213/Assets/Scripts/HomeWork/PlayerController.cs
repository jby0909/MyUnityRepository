using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int hp;
    int money;
    float exp;
    int speed = 10;
    int itemCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 1) * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -1) * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * speed;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "item")
        {
            itemCount++;
            Destroy(other.gameObject);
            Debug.Log(itemCount);
        }
    }
}
