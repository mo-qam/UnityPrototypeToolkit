using UnityEngine;

/// <summary>
/// Activates a random object from an array of GameObjects at the start of the scene
/// and ensures only one object is active at a time.
/// </summary>
public class RandomObjectActivator : MonoBehaviour
{
    [Tooltip("Array of GameObjects to choose from. Assign in the Unity Inspector.")]
    public GameObject[] objects;

    private void Start()
    {
        ActivateRandomObject();
    }

    /// <summary>
    /// Deactivates all objects in the array, then randomly activates one.
    /// </summary>
    private void ActivateRandomObject()
    {
        // Deactivate all objects
        foreach (GameObject obj in objects)
        {
            if (obj) // Simplified null check
            {
                obj.SetActive(false);
            }
        }

        // Ensure there is at least one object in the array
        if (objects.Length > 0)
        {
            // Randomly select and activate one object
            int randomIndex = Random.Range(0, objects.Length);
            if (objects[randomIndex]) // Simplified null check
            {
                objects[randomIndex].SetActive(true);
            }
        }
        else
        {
            Debug.LogWarning("RandomObjectActivator: 'objects' array is empty. Please assign GameObjects in the Unity Inspector.", this);
        }
    }
}
