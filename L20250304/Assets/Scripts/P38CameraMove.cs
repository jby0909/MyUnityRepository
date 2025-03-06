using UnityEngine;

public class P38CameraMove : MonoBehaviour
{
    Transform player;

    public float positionLagTime = 1.0f;
    public float rotationLagTime = 3.0f;

    Vector3 currentVelocity;
    Quaternion currentRotation;
    float smoothTime = 0.3f;
    float angleSmoothTime = 0.3f;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    //카메라가 마지막에 움직이도록 고정하기 위해 LateUpdate를 사용(순서가 뒤죽박죽이면 화면에서 부들부들떨리는 현상이 생길 수 있음)
    void LateUpdate()
    {

        //선형보간
        //transform.position = Vector3.Lerp(transform.position, player.position, Time.deltaTime * positionLagTime);
        //카메라 이동시 추천하는 함수 SmoothDamp (Lerp보다 좋다?)
        transform.position = Vector3.SmoothDamp(transform.position, player.position, ref currentVelocity, smoothTime);

        transform.rotation = Quaternion.Slerp(transform.rotation, player.rotation, Time.deltaTime * rotationLagTime);
        //transform.rotation = P38CameraMove.SmoothDamp(transform.rotation, player.rotation, ref currentRotation, angleSmoothTime);
        Debug.DrawLine(transform.position, Camera.main.transform.position, Color.red);
        
        
    }

    //쿼터니언의 SmoothDamp는 기본적으로 만들어져있지 않아서 인터넷에서 가져온 코드
    public static Quaternion SmoothDamp(Quaternion rot, Quaternion target, ref Quaternion deriv, float time)
    {
        if (Time.deltaTime < Mathf.Epsilon) return rot;
        // account for double-cover
        var Dot = Quaternion.Dot(rot, target);
        var Multi = Dot > 0f ? 1f : -1f;
        target.x = Multi;
        target.y = Multi;
        target.z = Multi;
        target.w = Multi;
        // smooth damp (nlerp approx)
        var Result = new Vector4(
            Mathf.SmoothDamp(rot.x, target.x, ref deriv.x, time),
            Mathf.SmoothDamp(rot.y, target.y, ref deriv.y, time),
            Mathf.SmoothDamp(rot.z, target.z, ref deriv.z, time),
            Mathf.SmoothDamp(rot.w, target.w, ref deriv.w, time)
        ).normalized;

        // ensure deriv is tangent
        var derivError = Vector4.Project(new Vector4(deriv.x, deriv.y, deriv.z, deriv.w), Result);
        deriv.x -= derivError.x;
        deriv.y -= derivError.y;
        deriv.z -= derivError.z;
        deriv.w -= derivError.w;

        return new Quaternion(Result.x, Result.y, Result.z, Result.w);
    }
}
