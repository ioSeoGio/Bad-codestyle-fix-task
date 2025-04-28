using UnityEngine;

public static class Vector3Extension
{
    public static float SqrDistance(this Vector3 start, Vector3 end)
    {
        return (end - start).sqrMagnitude;
    }

    public static bool IsInRange(this Vector3 start, Vector3 end, float range)
    {
        return start.SqrDistance(end) <= range * range;
    }
}