using System.Collections;
using UnityEngine;

public class ClearEffectController : MonoBehaviour
{
    public GameObject effectFactory;
    float currentTime;
    float checkTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = 0;
        checkTime = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > checkTime)
        {
            float deg = Random.Range(-180.0f, 180.0f);
            Effect(deg);
            currentTime = 0;
        }
        
        
    }
    void Effect(float deg)
    {
        GameObject effect = Instantiate(effectFactory);
        effect.transform.position = new Vector3(Mathf.Cos(deg), Mathf.Sin(deg), 0) * Random.Range(0, 8);
    }
}
