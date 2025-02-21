using UnityEngine;

public static class Util
{
    public static float GetAngleFromTo(Vector2 from, Vector2 to)
    {
        //from�� to�� ���̸� ���
        float dx = to.x - from.x;
        float dy = to.y - from.y;

        float radian = Mathf.Atan2(dy, dx);

        return radian;

    }
}
