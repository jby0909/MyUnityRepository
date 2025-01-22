using UnityEngine;


public enum Rainbow
{
    RED, ORANGE, YELLOW, GREEN, BLUE, INDIGO, VIOLET
}

[AddComponentMenu("JBY/Sample01")]
public class Sample01 : MonoBehaviour
{
    public bool jumpable;


    public string[] fruits;
    public int money;

    public Rainbow rainbow;

    [Range(1,99)]
    public float fieldview;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
