using UnityEngine;
using UnityEngine.EventSystems;

//����Ƽ���� �������ִ� Event, IPointer

//IPointer Interface
//Unity�� EventSystem���� �⺻������ �����Ǵ� �������̽�
//����ϱ� ���ؼ��� ������ ���� ������ �ʿ���

//Ŭ��, ��ġ, �巡�� ���� �̺�Ʈ�� ������ �� ���
//1.UI ������Ʈ���� Graphic Raycaster������Ʈ�� �߰��Ǿ� �־�� ��
//  �߰������� Raycast Target�� üũ�� �� ���¿��� ��

//2. Scene���� Event System ������Ʈ�� �����ؾ� ��

//3. ������Ʈ�� ���� �۾� �ÿ��� Collider������Ʈ�� �߰��Ǿ� �־�� ��

//4. Main Camera�� Physics Raycaster ������Ʈ�� �߰��Ǿ� �־�� ��

public class UInterSample : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Ŭ���� �����߽��ϴ�.");
    }

    //��� ���
    //1. �� ����� ����� ������Ʈ�� ����
    //2. ���� Event System������Ʈ�� ��ġ
    //   ���࿡ ���� ĵ���� ������ �����ߴٸ�, �ڵ����� ��ġ�� �Ǹ�, �ƴ� ����� ���� ���� ������
    //3. ������Ʈ�� �ݶ��̴��� ����
    //4. ī�޶� Physics Raycaster ������Ʈ�� ����

    //IPointerClickHandler
    //�ش� I�� �߰��ϸ� ���콺 Ŭ�� �Ǵ� ��ġ�� �� �� �� ȣ��Ǵ� �̺�Ʈ
    // ������ ���� ��� ȣ���

    //IPointerDownHandler
    //������ ������ ȣ��Ǵ� ���콺 Ŭ��/��ġ �̺�Ʈ

    //IPointerUpHandler
    //�� ��Ȳ�� ȣ��Ǵ� ���콺 Ŭ��/��ġ �̺�Ʈ

    //IBeginDragHandler
    //�巡�� ���� �� ȣ��Ǵ� �̺�Ʈ

    //IEndDragHandler
    //�巡�� ���� �� ȣ��Ǵ� �̺�Ʈ

    //IDragHandler
    //�巡�� ���� ���� ȣ��Ǵ� �̺�Ʈ
}
