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
        transform.Translate(Vector3.up * Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed);
        transform.eulerAngles += transform.forward * Time.deltaTime * -1 * Input.GetAxisRaw("Horizontal") * rotateSpeed;
        
        
        
    }
}
