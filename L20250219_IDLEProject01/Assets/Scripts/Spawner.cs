using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //몬스터는 맵에 특정 마리수를 몇 초마다 소환한다
    public GameObject monster_prefab;
    public int monster_count;
    public float monster_spawn_time;
    public float summon_rate = 5.0f;  // 해당 수치를 수저할 경우 생성되는 영역(구)의 위치 값이 점점 넓어짐
    public float re_rate = 2.0f;      // 생성 위치를 기준으로 생성되는 영역(구)를 설정할 수 있음

    public static List<Monster> monster_list = new List<Monster>(); // 생성된 몬스터
    public static List<Player> player_list = new List<Player>(); //생성된 캐릭터
    
    void Start()
    {
        StartCoroutine(SpawnMonsterPooling());
    }

    //일반적인 생성 방법
    IEnumerator SpawnMonster()
    {
        Vector3 pos; //생성좌표

        for (int i = 0; i < monster_count; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
            pos.y = 0.0f; // 생성된 유닛이 맵에 제대로 존재하기 위해 설정(공중에 떠있는거 방지용)

            //너무 근접한 범위에서 생성됐을 경우 재할당
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


    //오브젝트 풀링 기법으로 만드는 방법
    IEnumerator SpawnMonsterPooling()
    {
        Vector3 pos; //생성좌표

        for (int i = 0; i < monster_count; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
            pos.y = 0.0f; // 생성된 유닛이 맵에 제대로 존재하기 위해 설정(공중에 떠있는거 방지용)

            //너무 근접한 범위에서 생성됐을 경우 재할당
            while (Vector3.Distance(pos, Vector3.zero) <= re_rate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
                pos.y = 0.0f;
            }

            //전달할 함수가 없는 경우(일반생성)
            //var go = Manager.POOL.PoolObject("Monster").GetGameObject();


            //전달할 함수가 있는 경우(Action<GameObject>)
            //액션을 통해 기능 처리
            var go = Manager.POOL.PoolObject("Monster").GetGameObject((result) =>
            {
                //result.GetComponent<Monster>().MonsterSample();
                result.transform.position = pos;
                result.transform.LookAt(Vector3.zero);
                //생성한 유닛을 몬스터 리스트에 추가
                monster_list.Add(result.GetComponent<Monster>());

            });
            //풀링한 값에 대한 반납
            //StartCoroutine(ReturnMonsterPooling(go));
        }
       

        yield return new WaitForSeconds(monster_spawn_time);
        StartCoroutine(SpawnMonsterPooling());
    }

    //몬스터 풀링한 값에 대한 리턴 코드
    IEnumerator ReturnMonsterPooling(GameObject ob)
    {
        yield return new WaitForSeconds(1.0f);
        Manager.POOL.pool_dict["Monster"].ObjectReturn(ob);
    }

}
