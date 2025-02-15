using UnityEngine;

public class MonsterCreate : MonoBehaviour
{
    public GameObject monster;
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            int randx = Random.Range(-5, 5);
            int randz = Random.Range(-5, 5);
            Instantiate(monster, new Vector3(randx, 1, randz), Quaternion.identity);
        }
        
    }

    
}
