using UnityEngine;
using UnityEngine.Events; // Required for UnityEvent

public class OnEnableEventTrigger : MonoBehaviour
{
    [Tooltip("Event to invoke when this GameObject becomes active/enabled.")]
    [SerializeField]
    private UnityEvent onEnableEvent;

    /// <summary>
    /// Called when the GameObject becomes enabled and active.
    /// </summary>
    private void OnEnable()
    {
        onEnableEvent.Invoke(); // Invoke the UnityEvent
    }

    // The Start and Update methods have been removed since they're not used in this example.
}
