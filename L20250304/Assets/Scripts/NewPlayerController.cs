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

        //여기서 normalized를 하는 이유 : 대각선으로 움직일 때 값이 1보다 커져서 속도가 더 빨라지기때문에 모든 방향에서 속도를 일정하게 맞추기 위해서.
        transform.Translate(new Vector3(h, v, 0).normalized * Time.deltaTime * moveSpeed);
        //transform.eulerAngles += transform.forward * Time.deltaTime * -h * rotateSpeed;
        transform.Rotate(new Vector3(0, 0, -h) * Time.deltaTime * rotateSpeed);
        
        
    }
}
