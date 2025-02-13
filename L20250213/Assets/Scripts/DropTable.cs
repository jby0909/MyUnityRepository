using System.Collections.Generic;
using UnityEngine;

//CreateAssetMenu�� ����
//()�ȿ� fileName, menuName, order�� ������ �� ����
//fileName : �����Ǵ� ������ �̸�
//menuName : Create�� ���� ��������� �޴��� �̸��� ����. /�� ���� ��� ��ΰ� �߰���
//order : �޴� �߿��� ���° ��ġ�� ������ �� ǥ���� �� �����ϴ� ��. ���� Ŭ���� �������� ǥ���

[CreateAssetMenu(fileName = "DropTable", menuName ="DropTable/drop table", order = 0)]
public class DropTable : ScriptableObject
{
    public List<GameObject> drop_table;
}
