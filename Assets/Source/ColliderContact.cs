using System;
using UnityEngine;

public class ColliderContact : IContact
{
    IContact contact;
    Collider collider;
    public ColliderContact(IContact contact, Collider collider)
    {
        this.contact = contact;
        this.collider = collider;
    }

    public void Accept(Action<ContactPoint> action)
    {
        contact.Accept(c =>
        {
            if(c.thisCollider == collider)
            {
                action(c);
                Debug.Log(c.thisCollider.gameObject.name);
            }
        });
    }
}
