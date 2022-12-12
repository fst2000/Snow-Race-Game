using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBar
{
    float handleAngle;
    PlayerInput playerInput;
    public HandleBar()
    {
        handleAngle = 0f;
        playerInput = new PlayerInput();
    }
    public void Handle()
    {
        handleAngle = playerInput.MoveHorizontal * 30f;
    }
    public float GetAngle()
    {
        return handleAngle;
    }
    
}
