using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowCat
{
    Transform transform;
    Rigidbody rigidbody;
    BoxCollider skiLCollider;
    BoxCollider skiRCollider;
    BoxCollider skiFCollider;
    Ski skiL;
    Ski skiR;
    Ski skiF;
    public SnowCat(GameObject gameObject)
    {
        this.transform = gameObject.transform;
        this.rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        rigidbody.centerOfMass = new Vector3(0,0,0);

        skiL = new Ski(gameObject, new Vector3(-0.28f,0,-0.2f), new Vector3(0.2f, 0.05f, 0.9f), 0.7f);
        skiR = new Ski(gameObject, new Vector3(0.28f,0,-0.2f), new Vector3(0.2f, 0.05f, 0.9f), 0.7f);
        skiF = new Ski(gameObject, new Vector3(0,0,0.75f), new Vector3(0.2f, 0.05f, 0.5f), 0.65f);
    }
    public void Slide()
    {
        Ski[] skies = {skiL,skiR, skiF };
        foreach (Ski ski in skies)
        {
            ski.Slide();
        }

    }
}
