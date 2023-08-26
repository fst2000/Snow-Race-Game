using System;
using UnityEngine;

public class TransformForwardVector3 : IVector3
{
    Transform transform;

    public TransformForwardVector3(Transform transform)
    {
        this.transform = transform;
    }

    public void Accept(Action<Vector3> action)
    {
        action(transform.forward);
    }
}