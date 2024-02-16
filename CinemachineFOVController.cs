using UnityEngine;
using Cinemachine; // Ensure you have the Cinemachine namespace referenced

/// <summary>
/// Dynamically adjusts the FOV of a Cinemachine Virtual Camera based on an object's speed, typically a vehicle.
/// The FOV increases with speed to enhance the sense of speed and immersion.
/// </summary>
[RequireComponent(typeof(CinemachineVirtualCamera))] // Ensure there is a CinemachineVirtualCamera component
public class CinemachineFOVController : MonoBehaviour
{
    [Tooltip("Reference to the Cinemachine Virtual Camera.")]
    public CinemachineVirtualCamera virtualCamera;

    [Header("FOV Settings")]
    [Tooltip("Minimum FOV value.")]
    public float minFOV = 60f;
    [Tooltip("Maximum FOV value.")]
    public float maxFOV = 120f;

    [Header("Speed Settings")]
    [Tooltip("The speed at which the minimum FOV is applied.")]
    public float minSpeed = 0f;
    [Tooltip("The speed at which the maximum FOV is applied.")]
    public float maxSpeed = 100f;

    private void Reset()
    {
        // Automatically get the Cinemachine Virtual Camera component on reset
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    /// <summary>
    /// Public method to set the FOV based on the current speed of the object.
    /// </summary>
    /// <param name="carSpeed">The current speed of the object.</param>
    public void SetFOV(float carSpeed)
    {
        if (!virtualCamera) return; // Early exit if no virtual camera is assigned

        // Clamp the car speed to ensure it's within the defined speed range
        float clampedSpeed = Mathf.Clamp(carSpeed, minSpeed, maxSpeed);

        // Map the clamped speed to the FOV range
        float newFOV = Mathf.Lerp(minFOV, maxFOV, (clampedSpeed - minSpeed) / (maxSpeed - minSpeed));

        // Set the camera's FOV to the new value
        virtualCamera.m_Lens.FieldOfView = newFOV;
    }
}
