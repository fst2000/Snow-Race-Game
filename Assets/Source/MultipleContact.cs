using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleContact : MonoBehaviour, IContact
{
    List<ContactPoint> contacts;
    [SerializeField] new Collider collider;
    bool hasContact;
    void Start()
    {
        contacts = new();
    }
    void OnCollisionStay(Collision other)
    {
        other.GetContacts(contacts);
        hasContact = true;
    }
    public void Accept(Action<ContactPoint> action)
    {
        if(hasContact)
        {
            foreach(var c in contacts)
            {
                if(c.thisCollider == collider) action(c);
            }
            hasContact = false;   
        }
    }
}
