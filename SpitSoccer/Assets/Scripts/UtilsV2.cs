using UnityEngine;
using System.Collections;

public static class UtilsV2
{
    public static Vector3 GetDirectionV2(Vector3 a, Vector3 b)
    {
        return NormalizeV2(b - a);
    }
    public static Vector2 GetDirectionV2(Vector2 a, Vector2 b)
    {
        return NormalizeV2(b - a);
    }

    public static Vector3 NormalizeV2(Vector3 v)
    {
        if (v.x == 0 && v.y == 0) return Vector3.zero;
        return v / Mathf.Sqrt(v.x * v.x + v.y * v.y);
    }
    public static Vector2 NormalizeV2(Vector2 v)
    {
        if (v == Vector2.zero) return Vector2.zero;
        return v / Mathf.Sqrt(v.x * v.x + v.y * v.y);
    }

    public static Vector2 DirectionFromAngle (float angle)
    {
        angle *= Mathf.Deg2Rad;

        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }
}
