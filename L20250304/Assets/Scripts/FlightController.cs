using UnityEngine;

public class FlightController : MonoBehaviour
{
    float rotationSpeed = 60.0f;
    float moveSpeed = 30.0f;

    void Start()
    {
        
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        transform.Rotate(new Vector3(v, 0, -h).normalized * Time.deltaTime * rotationSpeed);
        
        
    }
}
