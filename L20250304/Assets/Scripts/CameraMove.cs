using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform player;

    Vector3 currentVelocity;
    Quaternion currentRotation;
    public float rotationLagTime = 3.0f;

    float smoothTime = 0.3f;
    public float angleSmoothTime = 0.3f;

    public bool isRotationLag = false;
    public bool isPositionLag = false;

    public Quaternion saveRotation;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    //ī�޶� �������� �����̵��� �����ϱ� ���� LateUpdate�� ���(������ ���׹����̸� ȭ�鿡�� �ε�ε鶳���� ������ ���� �� ����)
    void LateUpdate()
    {
        if(isPositionLag)
        {
            transform.position = Vector3.SmoothDamp(transform.position, player.position, ref currentVelocity, smoothTime);
        }
        else
        {
            transform.position = player.position;
        }

        if(isRotationLag)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, Time.deltaTime * rotationLagTime);
        }

        if(Input.GetButtonDown("Camera"))
        {
            saveRotation = transform.rotation;
        }
        if(Input.GetButtonUp("Camera"))
        {
            transform.rotation = saveRotation;
        }
        if(Input.GetButton("Camera"))
        {
            transform.Rotate(new Vector3(Input.mousePositionDelta.y * -1, Input.mousePositionDelta.x, 0) * 180.0f * Time.deltaTime);
        }

        float wheelDelta = Input.GetAxisRaw("Mouse ScrollWheel");

        Vector3 moveDirection = player.position - Camera.main.transform.position;
        Camera.main.transform.Translate(moveDirection.normalized * Time.deltaTime * wheelDelta * 200.0f, Space.World);

        Camera.main.transform.LookAt(player);
        

    }
}
