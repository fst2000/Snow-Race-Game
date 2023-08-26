using System;

public class SwitchBool : IBool
{
    IBool condition;
    bool switcher;
    public SwitchBool(IBool condition)
    {
        this.condition = condition;
    }
    public void Accept(Action<bool> action)
    {
        condition.Accept(b => 
        {
            if(b) switcher = !switcher;
        });
        action(switcher);
    }
}