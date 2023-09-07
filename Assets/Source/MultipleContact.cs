using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MultipleContact : MonoBehaviour, IContact
{
    List<ContactPoint> contacts;
    void Start()
    {
        contacts = new();
    }
    void OnCollisionEnter(Collision other)
    {
        other.GetContacts(contacts);
    }
    void OnCollisionStay(Collision other)
    {
        other.GetContacts(contacts);
    }
    void OnCollisionExit()
    {
        contacts.Clear();
    }
    public void Accept(Action<ContactPoint> action)
    {
        foreach(var c in contacts)
        {
            action(c);
        } 
    }
}
