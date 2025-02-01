using System.Collections;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject prefab;
    
    int randomPosX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("InstantiateObstacle");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator InstantiateObstacle()
    {
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(3);
            randomPosX = Random.Range(-6, 6);
            Instantiate(prefab, new Vector3(randomPosX, 4, 0), Quaternion.identity);
            
        }
    }

    
}
