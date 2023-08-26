using System;
using UnityEngine;

public class PositionVector3 : IVector3
{
    Transform transform;
    public PositionVector3(Transform transform)
    {
        this.transform = transform;
    }

    public void Accept(Action<Vector3> action)
    {
        action(transform.position);
    }
}