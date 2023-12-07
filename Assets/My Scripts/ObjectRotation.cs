using UnityEngine;

public class ObjectRotation : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust the rotation speed as needed

    void Update()
    {
        // Rotate the object around its up axis (Y-axis)
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
