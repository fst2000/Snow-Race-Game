using System;
using UnityEngine;

public class InputMoveVector3 : IVector3
{
    public void Accept(Action<Vector3> action)
    {
        action(Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), 1));
    }
}