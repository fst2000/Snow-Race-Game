using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] float cameraHeight = 1f;
    [SerializeField] float cameraDistance = -3f;
    [SerializeField] float cameraSpeed = 0.1f;
    [SerializeField] float intersectionIndent = 0.1f;
    Vector3 cameraAngles = new Vector3();
    void Update()
    {
        UnityEngine.Cursor.visible = false;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        Vector3 mouseInput = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));
        cameraAngles += mouseInput * cameraSpeed;
        cameraAngles.x = Math.Clamp(cameraAngles.x,-30,60);
        Quaternion cameraRotation = Quaternion.Euler(cameraAngles);
        Vector3 cameraPosition = origin.position + origin.rotation * new Vector3(0,cameraHeight,0) + cameraRotation * new Vector3(0, 0, cameraDistance);
        transform.rotation = cameraRotation;

        Vector3 rayOrigin = new Vector3(origin.position.x, cameraPosition.y + cameraHeight, origin.position.z);
        Vector3 rayDirection = cameraPosition - rayOrigin;
        rayDirection += rayDirection.normalized * intersectionIndent;

        if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hitInfo, rayDirection.magnitude))
        {
            cameraPosition = hitInfo.point + hitInfo.normal * intersectionIndent;
        }

        transform.position = cameraPosition;
    }
}
