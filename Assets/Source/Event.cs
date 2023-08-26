using System.Collections.Generic;
public class Event : IEvent
{
    List<EventDelegate> methods = new List<EventDelegate>();
    public void Call()
    {
        foreach(var method in methods)
        {
            method();
        }
    }

    public void Subscribe(EventDelegate method)
    {
        methods.Add(method);
    }
}