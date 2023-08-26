using System;
using UnityEngine;

public class TransformRotation : IRotation
{
    Transform transform;

    public TransformRotation(Transform transform)
    {
        this.transform = transform;
    }

    public void Accept(Action<Quaternion> action)
    {
        action(transform.rotation);
    }
}