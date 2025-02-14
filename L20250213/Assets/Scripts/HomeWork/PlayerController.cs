using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int hp = 100;
    int money = 0;
    float exp = 0;
    int speed = 10;
    int itemCount = 0;
    Quest quest;

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
        else if(other.gameObject.tag == "npc")
        {
            // Äù½ºÆ® ¹ß»ý
        }
        else if(other.gameObject.tag == "monster")
        {
            hp -= 10;
        }
    }
}
