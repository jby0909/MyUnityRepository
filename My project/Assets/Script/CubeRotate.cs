using UnityEngine;

/// <summary>
/// ť�긦 ȸ����Ű�� Ŭ����(������Ʈ)
/// </summary>
public class CubeRotate : MonoBehaviour
{
    #region �ʱ⳻��
    //�ڷ���(type)
    //���α׷��� �����͸� �Ǵ��ϴ� ����

    //���� ���Ǵ� �ڷ���
    //int : ����(Integer) : �Ҽ��� ���� ����
    //float : �Ǽ�(Float) : �Ҽ����� ���Ե� ����
    //bool : ��(Boolean) : �´��� Ʋ������ �Ǵ�(True, False)
    //string : ���ڿ�(String) : ������ ������ ǥ��(����)

    //����(variable)
    //� Ư�� �� �ϳ��� �����ϱ� ���� �̸��� ���� ���� ����

    //����� ���
    // �ڷ��� ������;

    //������ �� ����
    //������ ���� �����Ű�� �۾��� �ǹ�
    //������ = ��;

    #endregion

    #region ����
    public float x; //����Ƽ �����Ϳ��� �����Ǵ� ����
    public float z;
    private int sample; // ����Ƽ �����Ϳ��� �������� �ʴ� ����
    #endregion


    #region �Լ�
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sample = 10; //������ ������� ��� �ڵ� ���ο��� �����Ǵ� ��찡 ����.
        Debug.Log(sample);
        //""���� ������ ������ �� ���� ���� ���
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(x * Time.deltaTime,0,z * Time.deltaTime));
        //FPS(Frame Per Second) : �ʴ� ������
        //deltaTime : �� �������� �Ϸ�Ǳ���� �ɸ��� �ð�
    }
    #endregion
}
