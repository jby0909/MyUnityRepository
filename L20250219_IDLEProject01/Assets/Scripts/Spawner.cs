using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //���ʹ� �ʿ� Ư�� �������� �� �ʸ��� ��ȯ�Ѵ�
    public GameObject monster_prefab;
    public int monster_count;
    public float monster_spawn_time;
    public float summon_rate = 5.0f;  // �ش� ��ġ�� ������ ��� �����Ǵ� ����(��)�� ��ġ ���� ���� �о���
    public float re_rate = 2.0f;      // ���� ��ġ�� �������� �����Ǵ� ����(��)�� ������ �� ����

    public static List<Monster> monster_list = new List<Monster>(); // ������ ����
    public static List<Player> player_list = new List<Player>(); //������ ĳ����
    
    void Start()
    {
        StartCoroutine(SpawnMonsterPooling());
    }

    //�Ϲ����� ���� ���
    IEnumerator SpawnMonster()
    {
        Vector3 pos; //������ǥ

        for (int i = 0; i < monster_count; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
            pos.y = 0.0f; // ������ ������ �ʿ� ����� �����ϱ� ���� ����(���߿� ���ִ°� ������)

            //�ʹ� ������ �������� �������� ��� ���Ҵ�
            while (Vector3.Distance(pos, Vector3.zero) <= re_rate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
                pos.y = 0.0f;
            }

            GameObject go = Instantiate(monster_prefab, pos, Quaternion.identity);
        }
        yield return new WaitForSeconds(monster_spawn_time);
        StartCoroutine(SpawnMonster());
    }


    //������Ʈ Ǯ�� ������� ����� ���
    IEnumerator SpawnMonsterPooling()
    {
        Vector3 pos; //������ǥ

        for (int i = 0; i < monster_count; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
            pos.y = 0.0f; // ������ ������ �ʿ� ����� �����ϱ� ���� ����(���߿� ���ִ°� ������)

            //�ʹ� ������ �������� �������� ��� ���Ҵ�
            while (Vector3.Distance(pos, Vector3.zero) <= re_rate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
                pos.y = 0.0f;
            }

            //������ �Լ��� ���� ���(�Ϲݻ���)
            //var go = Manager.POOL.PoolObject("Monster").GetGameObject();


            //������ �Լ��� �ִ� ���(Action<GameObject>)
            //�׼��� ���� ��� ó��
            var go = Manager.POOL.PoolObject("Monster").GetGameObject((result) =>
            {
                //result.GetComponent<Monster>().MonsterSample();
                result.transform.position = pos;
                result.transform.LookAt(Vector3.zero);
                //������ ������ ���� ����Ʈ�� �߰�
                monster_list.Add(result.GetComponent<Monster>());

            });
            //Ǯ���� ���� ���� �ݳ�
            //StartCoroutine(ReturnMonsterPooling(go));
        }
       

        yield return new WaitForSeconds(monster_spawn_time);
        StartCoroutine(SpawnMonsterPooling());
    }

    //���� Ǯ���� ���� ���� ���� �ڵ�
    IEnumerator ReturnMonsterPooling(GameObject ob)
    {
        yield return new WaitForSeconds(1.0f);
        Manager.POOL.pool_dict["Monster"].ObjectReturn(ob);
    }

}
