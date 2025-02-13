using UnityEngine;

public class GoldBallController : MonoBehaviour
{
    public GameObject goldBall;
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            //z : -9 ~ 16 ,x : -11 ~ 9  
            float randx = Random.Range(-11, 10);
            float randz = Random.Range(-9, 17);
            Instantiate(goldBall, new Vector3(randx, 0.25f, randz), Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
