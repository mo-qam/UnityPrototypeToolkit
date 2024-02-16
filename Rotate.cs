using UnityEngine;

/// <summary>
/// Rotates an object around its local axes based on specified speed and direction.
/// </summary>
public class Rotate : MonoBehaviour
{
    [Header("Rotational Settings")]
    [Tooltip("Rotation speed in degrees per second.")]
    public float speed = 10f; // Adjusted default speed for better demonstration

    [Header("Forward Direction Rotation")]
    public bool rotateForwardX = false;
    public bool rotateForwardY = false;
    public bool rotateForwardZ = false;

    [Header("Reverse Direction Rotation")]
    public bool rotateReverseX = false;
    public bool rotateReverseY = false;
    public bool rotateReverseZ = false;

    void Update()
    {
        RotateObject();
    }

    /// <summary>
    /// Rotates the object based on the specified axes and direction.
    /// </summary>
    void RotateObject()
    {
        // Calculate rotation for each axis
        float rotationX = (rotateForwardX ? 1 : 0) - (rotateReverseX ? 1 : 0);
        float rotationY = (rotateForwardY ? 1 : 0) - (rotateReverseY ? 1 : 0);
        float rotationZ = (rotateForwardZ ? 1 : 0) - (rotateReverseZ ? 1 : 0);

        // Apply rotation
        Vector3 rotation = new Vector3(rotationX, rotationY, rotationZ) * speed * Time.deltaTime;
        transform.Rotate(rotation, Space.Self);
    }
}
