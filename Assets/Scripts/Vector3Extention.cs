using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extension
{
    public static float SqrDistance(this Vector3 start, Vector3 end)
    {
        return (end - start).sqrMagnitude;
    }

    public static bool IsInRange(this Vector3 start, Vector3 end, float range)
    {
        Debug.Log("pos:" + start);
        Debug.Log("point pos:" + end);

        Debug.Log(start.SqrDistance(end));
        return start.SqrDistance(end) <= range * range;
    }
}