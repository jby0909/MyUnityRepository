using UnityEngine;

public class CircleMove : MonoBehaviour
{
    //Circle�� ������ ��ġ�� Lerp��Ű�� ��ũ��Ʈ
    public GameObject Circle;
    Vector3 pos = new Vector3(5, -3, 0);


    // Update is called once per frame
    void Update()
    {
        //Vector3.Lerp(��������, ������, ������)
        //������ 0�� �Է��� ��� �������� ����
        //������ 1�� �ִ�ġ
        //Circle.transform.position = Vector3.Lerp(Circle.transform.position, pos, Time.deltaTime);

        //������ �ӵ��� ��ǥ �������� �̵��ϰ� ����� ��ũ��Ʈ
        //Vector3.MoveTowards(��������, ������, �̵��ӵ�)
        //Circle.transform.position = Vector3.MoveTowards(Circle.transform.position, pos, Time.deltaTime);

        //Lerp�� ����ѵ� ������ �ƴ� ȣ�� �׸��鼭 �̵�
        Circle.transform.position = Vector3.Slerp(Circle.transform.position, pos, 0.05f);
    }
}
