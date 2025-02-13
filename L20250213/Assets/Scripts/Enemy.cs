using System;
using UnityEngine;

//using System�� ����ϸ鼭 ����Ƽ�� Random�� ����ϰ� ���� ���
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    //������ ��� ���̺�
    public DropTable _DropTable;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            Dead();
        }
    }

    private void Dead()
    {
        GameObject dropItemPrefab = _DropTable.drop_table[Random.Range(0, _DropTable.drop_table.Count)];
        //Random.Range(�ּ�, �ִ�)�� ����Ƽ���� �������ִ� ���� ����
        //�ּҰ����� �ִ�-1 ������ ������ �� �� �ϳ��� �������� ����

        Instantiate(dropItemPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
