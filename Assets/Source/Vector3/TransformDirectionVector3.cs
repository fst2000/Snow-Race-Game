using System;
using UnityEngine;

public class TransformDirectionVector3 : IVector3
{
    IVector3 vector3;
    Transform transform;

    public TransformDirectionVector3(IVector3 vector3, Transform transform)
    {
        this.vector3 = vector3;
        this.transform = transform;
    }

    public void Accept(Action<Vector3> action)
    {
        vector3.Accept(v3 => action(transform.TransformDirection(v3)));
    }
}