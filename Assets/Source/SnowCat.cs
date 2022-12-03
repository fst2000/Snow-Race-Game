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

        skiL = new Ski(Vector3.left, new Vector3(0.2f, 0.05f, 1f), 0.7f);
        skiR = new Ski(Vector3.right, new Vector3(0.2f, 0.05f, 1f), 0.7f);
        skiF = new Ski(Vector3.forward, new Vector3(0.2f, 0.05f, 1f), 0.7f);

        skiLCollider = new BoxCollider();
        skiLCollider.size = skiL.GetSize();
        skiLCollider.center = skiL.GetLocalCenter();

        skiRCollider = new BoxCollider();
        skiRCollider.size = skiR.GetSize();
        skiRCollider.center = skiR.GetLocalCenter();

        skiFCollider = new BoxCollider();
        skiFCollider.size = skiF.GetSize();
        skiFCollider.center = skiF.GetLocalCenter();
    }
    public void Slide()
    {

    }
}
