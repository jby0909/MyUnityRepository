using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public GameObject prefab;
    public Transform[] spawnPoint;

    private void Awake()
    {
       spawnPoint = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            for(int i = 0; i <spawnPoint.Length; i++)
            {
                GameObject bullet = Instantiate(prefab);
                bullet.transform.position = spawnPoint[i].position;
                bullet.transform.rotation = spawnPoint[i].rotation;
            }
           
            
        }
    }
}
