using System;
using UnityEngine; // NameSpace : �Ҽ�


public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 5.0f; //�÷��̾� �̵� �ӵ�
    public float mouseSensitivity = 100.0f; // ���콺 ����
    public Transform cameraTransform; // ī�޶��� Transform
    public CharacterController characterController;
    public Transform playerHead; //�÷��̾� �Ӹ� ��ġ(1��Ī ��带 ���ؼ�)
    public float thirdPersonDistance = 3.0f; // 3��Ī ��忡�� �÷��̾�� ī�޶��� �Ÿ�
    public Vector3 thirdPersonOffset = new Vector3(0f, 1.5f, 0f); //3��Ī ��忡�� ī�޶� ������
    public Transform playerLookObj; //�÷��̾� �þ� ��ġ

    public float zoomeDistance = 1.0f; //ī�޶� Ȯ��ɶ��� �Ÿ�(3��Ī ��忡�� ���)
    public float zoomSpeed = 5.0f; //Ȯ����Ұ� �Ǵ� �ӵ�
    public float defaultFov = 60.0f; //�⺻ ī�޶� �þ߰�
    public float zoomeFov = 30.0f; //Ȯ�� �� ī�޶� �þ߰�(1��Ī ��忡�� ���)

    private float currentDistance; //���� ī�޶���� �Ÿ�(3��Ī ���)
    private float targetDistance; //��ǥ ī�޶� �Ÿ�
    private float targetFov; //��ǥ FOV
    private bool isZoomed = false; // Ȯ�� ���� Ȯ��
    private Coroutine zoomCoroutine; //�ڷ�ƾ�� ����Ͽ� Ȯ�� ��� ó��
    private Camera mainCamera; //ī�޶� ������Ʈ

    private float pitch = 0.0f; //���Ʒ� ȸ�� ��
    private float yaw = 0.0f; //�¿� ȸ����
    private bool isFirstPerson = false; //1��Ī ��� ����
    private bool isRotaterAroundPlayer = true; //ī�޶� �÷��̾� ������ ȸ���ϴ��� ����

    //�߷� ���� ����
    public float gravity = -9.81f; //CharacterController������ �߷��� ����ȵż� ���� �������ش�?
    public float jumpHeight = 2.0f;
    private Vector3 velocity;
    private bool isGround; //���� ��Ҵ��� ����

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentDistance = thirdPersonDistance;
        targetDistance = thirdPersonDistance;
        targetFov = defaultFov;
        mainCamera = cameraTransform.GetComponent<Camera>();
        mainCamera.fieldOfView = defaultFov;
    }

    void Update()
    {
        //���콺 �Է��� �޾� ī�޶� �÷��̾� ȸ�� ó��
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw += mouseX;
        pitch -= mouseY;
        //���� ����(3��Ī���ӿ��� ���� -45 ~ 45 �� ���� ����) 
        pitch = Mathf.Clamp(pitch, -45f, 45f);

        isGround = characterController.isGrounded;

        if(isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            isFirstPerson = !isFirstPerson;
            Debug.Log(isFirstPerson ? "1��Ī ���" : "3��Ī ���");
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            isRotaterAroundPlayer = !isRotaterAroundPlayer;
            Debug.Log(isRotaterAroundPlayer ? "ī�޶� ������ ȸ���մϴ�." : "�÷��̾��� �þ߿� ���� ȸ���մϴ�.");
        }

        if (isFirstPerson)
        {
            FirstPersonMovement();
        }
        else
        {
            ThirdPersonMovement();
        }
    }

    //���� �ּ��� �� ���� �ؼ�
    void FirstPersonMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = cameraTransform.forward * vertical + cameraTransform.right * horizontal; //ī�޶� �������� �̵������� ���
        moveDirection.y = 0; //�� �̵������� y ��ǥ�� 0���� ����(ĳ���ʹ� ���Ϸ� �̵����� ���� ���̹Ƿ�. y���� �̵��� ����)
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime); //ĳ���͸� �ش� �������� ������ �ӵ���ŭ �̵�

        cameraTransform.position = playerHead.position; //ī�޶��� ��ġ�� �÷��̾��� �Ӹ��� ��ġ�� ���� �ű��
        cameraTransform.rotation = Quaternion.Euler(pitch, yaw, 0); //ī�޶��� ȸ���� ����

        transform.rotation = Quaternion.Euler(0f, cameraTransform.eulerAngles.y, 0); // ĳ������ ȸ���� ī�޶� y��ȸ����ŭ�� ȸ��(ĳ���ʹ� �¿츸 �����ϰ��̹Ƿ�)
    }

    void ThirdPersonMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * moveSpeed * Time.deltaTime);

        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        //ī�޶� �÷��̾� ������ ȸ���ϴ� �κ�
        if(isRotaterAroundPlayer)
        {
            //ī�޶� �÷��̾� �����ʿ��� ȸ���ϵ��� ����
            Vector3 direction = new Vector3(0, 0, -currentDistance);
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

            //ī�޶� �÷��̾��� �����ʿ��� ������ ��ġ�� �̵�
            cameraTransform.position = transform.position + thirdPersonOffset + rotation * direction;

            //ī�޶� �÷��̾��� ��ġ�� ���󰡵��� ����
            cameraTransform.LookAt(transform.position + new Vector3(0, thirdPersonOffset.y, 0));
        }
        else
        {
            //�÷��̾��� �þ߿� ���� ȸ���ϴ� �κ�
            transform.rotation = Quaternion.Euler(0f, yaw, 0);
            Vector3 direction = new Vector3(0, 0, -currentDistance);
            cameraTransform.position = playerLookObj.position + thirdPersonOffset + Quaternion.Euler(pitch, yaw, 0) * direction;
            cameraTransform.LookAt(playerLookObj.position + new Vector3(0, thirdPersonOffset.y, 0));
        }
       
    }
}
