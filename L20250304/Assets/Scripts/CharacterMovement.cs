using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    public float rotationSpeed = 360.0f;
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.forward * v * Time.deltaTime * moveSpeed);
        transform.Rotate(Vector3.up * -h * Time.deltaTime * moveSpeed * rotationSpeed);
    }
}
