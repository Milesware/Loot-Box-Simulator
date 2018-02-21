using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Math  {

    private static float mTolerance = 0.5f;

    public static bool isCloseEnuf(Vector2 a, Vector2 b)
    {
        Vector2 diff = a - b;
        return (diff.x < mTolerance && diff.y < mTolerance);
    }
}
