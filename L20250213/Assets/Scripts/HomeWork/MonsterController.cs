using UnityEngine;

public class MonsterController : MonoBehaviour
{
    float x = 1;
    float z = 1;
    void Start()
    {
        
    }

    
    void Update()
    {
        float rand1 = Random.Range(0.5f, 1);
        float rand2 = Random.Range(-1, -0.5f);
        if(transform.position.x < -10 && transform.position.z > 30)
        {
            x = rand1;
            z = -rand2;
        }
        else if (transform.position.x < -10 && transform.position.z < -10)
        {
            
            x = rand1;
            z = rand1;
        }
        else if (transform.position.x > 10 && transform.position.z > 30)
        {
            
            x = rand2;
            z = rand2;
        }
        else if (transform.position.x > 10 && transform.position.z < -10)
        {
            
            x = rand2;
            z = rand1;
        }
        transform.position += new Vector3(x, 0, z) * Time.deltaTime * 10;
    }
}
