using System;
using UnityEngine;
public class KeyboardMoveInput : IVector2
{
    public void Accept(Action<Vector2> consumer)
    {
        consumer(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    }
}