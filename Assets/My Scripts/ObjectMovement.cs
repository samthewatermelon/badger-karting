using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float amplitude = 1f;         // Adjust the height of the object's movement
    public float frequency = 1f;         // Adjust the speed of the object's movement

    private Vector3 startPosition;
    private float time = 0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        time += Time.deltaTime;

        // Calculate the new position using a sine wave
        float newY = startPosition.y + Mathf.Sin(time * frequency) * amplitude;

        // Update the object's position
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}
