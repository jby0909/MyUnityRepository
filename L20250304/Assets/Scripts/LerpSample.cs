using UnityEngine;

public class LerpSample : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public AnimationCurve curve;

    private Material mat;

    float elapsedTime = 0;
    float sign = 1;

    public Color AColor;
    public Color BColor;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime * sign;

        if(elapsedTime > 1 || elapsedTime < 0)
        {
            sign = sign * -1;
        }

        transform.position = Vector3.Lerp(A.position, B.position, curve.Evaluate(elapsedTime));
        transform.rotation = Quaternion.Slerp(A.rotation, B.rotation, curve.Evaluate(elapsedTime));

        mat.SetColor("_BaseColor", Color.Lerp(AColor, BColor, curve.Evaluate(elapsedTime)));
        //mat.color = Color.Lerp(AColor, BColor, curve.Evaluate(elapsedTime));
    }
}
