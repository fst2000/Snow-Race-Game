using UnityEngine;
using System;
public interface IContact
{
    void Accept(Action<ContactPoint> action);
}