using UnityEngine;

public class RoundMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, 8.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "obstacle")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }
}
