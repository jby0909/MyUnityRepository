using System;
using UnityEngine;

public class ItemSample : MonoBehaviour
{
    //������ ���
    public Item item;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ItemInfo();
        }
    }

    private void ItemInfo()
    {
        //��ũ���ͺ� ������Ʈ�� ���� �� �ٿ��� �̸�
        Debug.Log(item.name); 

        //��ũ���ͺ� ������Ʈ���� ������ ����
        Debug.Log(item.id); 
        Debug.Log(item.description);
        Debug.Log(item.price);
    }
}
