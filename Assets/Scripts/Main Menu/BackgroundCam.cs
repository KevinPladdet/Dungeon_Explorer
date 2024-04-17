using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundCam : MonoBehaviour
{

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    [SerializeField] private int yRotationValue;

    private void Start()
    {
        transform.localRotation = Quaternion.Euler(0, yRotationValue, 0);
        // Saves position and rotation of camera
        initialPosition = transform.position;
        initialRotation = transform.localRotation;
    }

    private void LateUpdate()
    {
        // Resets position and rotation of camera (to prevent it from moving)
        transform.position = initialPosition;
        transform.rotation = Quaternion.Euler(0, yRotationValue, 0);
    }
}
