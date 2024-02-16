using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Listens for a specific key press and triggers a UnityEvent in response.
/// The event is triggered only once per key press to prevent repeated firing
/// while the key is held down.
/// </summary>
public class KeyDownInput : MonoBehaviour
{
    [Tooltip("The key to listen for.")]
    [SerializeField] private KeyCode key;

    [Tooltip("Event to invoke when the specified key is pressed.")]
    [SerializeField] private UnityEvent onKeyPressEvent;

    private bool triggered = false; // Flag to prevent repeated event firing

    void Update()
    {
        CheckForKeyPress();
    }

    /// <summary>
    /// Checks if the designated key is pressed and triggers an event accordingly.
    /// Resets the trigger state on key release to allow for subsequent activations.
    /// </summary>
    private void CheckForKeyPress()
    {
        // Trigger event on key down if not already triggered
        if (Input.GetKeyDown(key) && !triggered)
        {
            onKeyPressEvent.Invoke();
            triggered = true;
        }
        // Reset trigger state on key up
        else if (Input.GetKeyUp(key) && triggered)
        {
            triggered = false;
        }
    }
}
