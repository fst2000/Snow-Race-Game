using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Ski
{
    Vector3 localCenter;
    Vector3 size;
    float drift;
    public Ski(Vector3 localCenter, Vector3 size,float drift)
    {
        this.localCenter = localCenter;
        this.size = size;
        this.drift = drift;
    }
    public Vector3 GetLocalCenter()
    {
        return localCenter;
    }
    public Vector3 GetSize()
    {
        return size;
    }
    public float GetDrift()
    {
        return drift;
    }
}
