using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyFactory;
    public GameObject bossFactory;
    public int enemy_count;
    
    GameObject[] enemys;
    GameObject boss;



    void Start()
    {



    }

    public void SpawnMonsterStage()
    {
         enemys = new GameObject[enemy_count];
        for(int i = 0; i < enemy_count; i++)
        {
            int rand = Random.Range(0, 8);
            int rand2 = Random.Range(0, 3);
            enemys[i] = Instantiate(enemyFactory, new Vector3(Mathf.Cos(45.0f * rand), Mathf.Sin(45.0f * rand), 0) * rand2,Quaternion.identity);
        }
        boss = Instantiate(bossFactory, Vector3.zero, Quaternion.identity);
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy_count == 0 && !BossController.isDead)
        {
            boss.SetActive(true);
        }
        
    }
}
