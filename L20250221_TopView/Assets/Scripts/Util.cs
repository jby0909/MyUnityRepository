using UnityEngine;

public static class Util
{
    public static float GetAngleFromTo(Vector2 from, Vector2 to)
    {
        //from과 to의 차이를 계산
        float dx = to.x - from.x;
        float dy = to.y - from.y;

        float radian = Mathf.Atan2(dy, dx);

        return radian;

    }
}
