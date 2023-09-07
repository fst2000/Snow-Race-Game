using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnowcatBehaviour : MonoBehaviour
{
    [SerializeField] MultipleContact snowcatContact;
    [SerializeField] GameObject handlingSki;
    SnowcatSki[] skies;
    Transform handlingSkiTransform;
    void Start()
    {
        skies = new SnowcatSki[]
        {
            new SnowcatSki(handlingSki, snowcatContact, new Vector3(0,0,0), 0.1f, 0.5f, 0.2f, 0.05f),
            new SnowcatSki(gameObject, snowcatContact, new Vector3(-0.2f ,0, 0), 0.1f, 1f, 0.1f, 0.2f),
            new SnowcatSki(gameObject, snowcatContact, new Vector3(0.2f ,0, 0), 0.1f, 1f, 0.1f, 0.2f)
        };
        handlingSkiTransform = handlingSki.transform;
    }
    void Update()
    {
        handlingSkiTransform.rotation = Quaternion.LookRotation(transform.forward, transform.up) * Quaternion.Euler(0, Input.GetAxis("Horizontal") * 60, 0);
    }
    void FixedUpdate()
    {
        foreach(var ski in skies)
        {
            ski.Slide();
        }
    }
}
