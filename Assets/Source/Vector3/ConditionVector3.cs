using System;
using UnityEngine;

public class ConditionVector3 : IVector3
{
    IBool condition;
    IVector3 onTrue;
    IVector3 onFalse;

    public ConditionVector3(IBool condition, IVector3 onTrue, IVector3 onFalse)
    {
        this.condition = condition;
        this.onTrue = onTrue;
        this.onFalse = onFalse;
    }

    public void Accept(Action<Vector3> action)
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
