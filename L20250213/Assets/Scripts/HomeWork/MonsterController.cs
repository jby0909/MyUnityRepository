using System;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    float x = 1;
    float z = 1;
    

    void Start()
    {
        QuestEvent.QuestEventHandler += QuestClear;
        
    }

    private void QuestClear(object sender, EventArgs e)
    {
        Debug.Log("¸ó½ºÅÍ ÆÄ±«");
        Destroy(gameObject);
    }

    void Update()
    {
        if(transform.position.x < -5)
        {
            x = 1;
            if (transform.position.z > 10)
            {
                z = -1;
            }
            else if(transform.position.z < -5)
            {
                z = 1;
            }
        }
        else if (transform.position.x > 5)
        {
            x = -1;
            if (transform.position.z > 10)
            {
                z = -1;
            }
            else if(transform.position.z < -5)
            {
                z = 1;
            }
        }
        transform.position += new Vector3(x, 0, z) * Time.deltaTime * 10;
    }
}
