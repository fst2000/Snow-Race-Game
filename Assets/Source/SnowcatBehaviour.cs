using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SnowcatBehaviour : MonoBehaviour
{
    [SerializeField] Transform handlingSki;
    void Update()
    {
        handlingSki.rotation = Quaternion.LookRotation(transform.forward, transform.up) * Quaternion.Euler(0, Input.GetAxis("Horizontal") * 60, 0);
    }
}
