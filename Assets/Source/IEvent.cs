public interface IEvent
{
    void Subscribe(EventDelegate method);
    void Call();
}
public delegate void EventDelegate();