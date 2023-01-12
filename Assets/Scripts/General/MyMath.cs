using UnityEngine;

public class MyMath
{
    public static float GetAim(Vector2 p1, Vector2 p2)
    {
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);
        return rad * Mathf.Rad2Deg;
    }

    public static Vector3 ClampPos(Vector3 pos, float width, float height)
    {
        if (pos.x > width / 2)
            pos.x = width / 2;
        else if (pos.x < -width / 2)
            pos.x = -width / 2;

        if (pos.y > height / 2)
            pos.y = height / 2;
        else if (pos.y < -height / 2)
            pos.y = -height / 2;

        return pos;
    }
}
