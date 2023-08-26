using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowcatBehaviour : MonoBehaviour
{
    RayHit hit;
    Event fixedUpdate;
    void Start()
    {
        fixedUpdate = new Event();

        Vector3Func down = v3Action => v3Action(-transform.up);
        Vector3Func position = v3Action => v3Action(transform.position);
        hit = new RayHit(fixedUpdate, position, down);
    }
    void Update()
    {
        hit.Accept(hit => Debug.Log(hit.distance));
    }
    void FixedUpdate()
    {
        fixedUpdate.Call();
    }
}
