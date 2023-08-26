using System;
using UnityEngine;
public interface IHit
{
    void Accept(Action<RaycastHit> action);
}