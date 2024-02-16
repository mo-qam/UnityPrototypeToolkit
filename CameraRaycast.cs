using UnityEngine;

/// <summary>
/// Demonstrates the use of raycasting from the camera to a target object,
/// highlighting interaction capabilities without applying transformations.
/// </summary>
public class CameraRaycast : MonoBehaviour
{
    [Header("Configuration")]
    [Tooltip("Reference to the main camera in the scene.")]
    public GameObject mainCamera;

    [Tooltip("The target object to detect with raycasting.")]
    public GameObject target;

    [Tooltip("Layer mask to filter raycast hits.")]
    public LayerMask targetLayerMask;

    [Tooltip("Maximum distance for the raycast.")]
    public float raycastDistance = 100f;

    private Transform mainCameraTransform;
    private Transform targetTransform;

    private void Start()
    {
        // Cache Transform components for optimized performance.
        mainCameraTransform = mainCamera.transform;
        targetTransform = target.transform;
    }

    private void Update()
    {
        PerformRaycastCheck();
    }

    /// <summary>
    /// Performs a raycast from the camera towards the target. Logs a message if the target is hit.
    /// </summary>
    private void PerformRaycastCheck()
    {
        Vector3 direction = (targetTransform.position - mainCameraTransform.position).normalized;

        if (Physics.Raycast(mainCameraTransform.position, direction, out RaycastHit hit, raycastDistance, targetLayerMask))
        {
            // Log hit information for demonstration purposes.
            if (hit.collider.gameObject == target) // Ensures the hit object is the specific target.
            {
                Debug.Log($"Raycast hit target: {hit.collider.gameObject.name}");
            }
        }
    }
}
