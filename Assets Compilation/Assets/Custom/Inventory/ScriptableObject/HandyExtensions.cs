using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HandyExtensions
{
    public static bool HasComponent<T>(this GameObject obj)
    {
        return obj.GetComponent<T>() != null;
    }
}
