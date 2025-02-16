using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windmills : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f; // Geschwindigkeit der Rotation
    private bool isRotating = false; // Status der Rotation

    public void ToggleRotation()
    {
        isRotating = !isRotating;
    }

    private void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }
}
