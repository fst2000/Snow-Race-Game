using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleContact : MonoBehaviour, IContact
{
    List<ContactPoint> contacts;
    bool hasContact;
    void Start()
    {
        contacts = new();
    }
    void OnCollisionEnter(Collision other)
    {
        other.GetContacts(contacts);
        hasContact = true;
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
                action(c);
            }
            hasContact = false;   
        }
    }
}
