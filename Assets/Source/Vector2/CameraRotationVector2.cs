using System;
using UnityEngine;

public class CameraRotationVector2 : IVector2
{
    Vector2Func rotationInput;
    Vector2 rotation;
    float maxAngle;
    public CameraRotationVector2(Vector2Func rotationInput, float maxAngle)
    {
        this.rotationInput = rotationInput;
        this.maxAngle = maxAngle;
    }
    public void Accept(Action<Vector2> action)
    {
        rotationInput(input => rotation += input);
        rotation.y = Mathf.Clamp(rotation.y, -maxAngle, maxAngle);
        action(rotation);
    }
}