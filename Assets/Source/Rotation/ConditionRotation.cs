using System;
using UnityEngine;

public class ConditionRotation : IRotation
{
    IBool condition;
    IRotation onTrue;
    IRotation onFalse;

    public ConditionRotation(IBool condition, IRotation onTrue, IRotation onFalse)
    {
        this.condition = condition;
        this.onTrue = onTrue;
        this.onFalse = onFalse;
    }

    public void Accept(Action<Quaternion> action)
    {
        onTrue.Accept(onTrue =>
        {
            onFalse.Accept(onFalse =>
            {
                condition.Accept(b =>
                {
                    action(b? onTrue : onFalse);
                });
            });
        });
    }
}
