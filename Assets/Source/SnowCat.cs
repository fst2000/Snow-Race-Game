using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SnowCat
{
    Rigidbody rigidbody;
    [SerializeField] Transform handleTransform;
    [SerializeField] Transform skiFTransform;
    Transform transform;
    HandleBar handleBar = new HandleBar();

    Ski skiL;
    Ski skiR;
    Ski skiF;
    PlayerInput playerInput;
    public void Initialize(GameObject gameObject)
    {
        transform = gameObject.transform;
        playerInput = new PlayerInput();
        this.rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        rigidbody.centerOfMass = new Vector3(0, 0, 0.11f);
        rigidbody.mass = 60f;
        rigidbody.drag = 0.1f;
        rigidbody.angularDrag = 0.5f;

        skiL = new Ski(gameObject, new Vector3(-0.28f, 0.1f, -0.1f), new Vector3(0.2f, 0.05f, 1.2f), 0.2f);
        skiR = new Ski(gameObject, new Vector3(0.28f, 0.1f, -0.1f), new Vector3(0.2f, 0.05f, 1.2f), 0.2f);
        skiF = new Ski(gameObject, new Vector3(0, 0.1f, 0.75f), new Vector3(0.2f, 0.05f, 0.5f), 0.3f);
    }
    public void SnowCatSlide(Vector3 normal, Vector3 point)
    {
        Ski[] skies = {skiL, skiR, skiF};
        foreach (Ski ski in skies)
        {
            ski.SkiSlide(normal, point);
        }

    }
    public void Control()
    {
        handleBar.Handle();
        handleTransform.localRotation = Quaternion.Euler(-30, 0, handleBar.GetAngle());
        skiFTransform.localRotation = Quaternion.Euler(0, 0, handleBar.GetAngle());
        skiF.SkiRotate(handleBar.GetAngle());
    }
}
