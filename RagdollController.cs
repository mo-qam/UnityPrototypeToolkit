using UnityEngine;
using System.Collections;

/// <summary>
/// Manages a character's ragdoll state, enabling and disabling ragdoll physics based on collisions and optionally resetting after a delay.
/// </summary>
public class RagdollController : MonoBehaviour
{
    [Header("Ragdoll Settings")]
    [SerializeField]
    private bool isRagdolled = false;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip ragdollSound;
    [SerializeField]
    private float ragdollDuration = 5.0f;
    [SerializeField]
    private float impactThreshold = 10.0f;
    [SerializeField]
    private Vector3 forceDirection = Vector3.up;
    [SerializeField]
    private float forceMagnitude = 500.0f;

    [Header("Behavior Settings")]
    public bool ResetRagdollAfterDelay = false;
    public bool UseImpactThreshold = false;

    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Rigidbody[] ragdollRigidbodies;

    private void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();

        SetRagdollState(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isRagdolled && (UseImpactThreshold && collision.impulse.magnitude > impactThreshold) || !UseImpactThreshold)
        {
            ActivateRagdoll();
            if (ResetRagdollAfterDelay)
            {
                StartCoroutine(ResetAfterDelay(ragdollDuration));
            }
        }
    }

    /// <summary>
    /// Activates or deactivates the ragdoll state of the character.
    /// </summary>
    /// <param name="state">Whether the ragdoll state should be activated.</param>
    private void SetRagdollState(bool state)
    {
        isRagdolled = state;
        animator.enabled = !state;

        foreach (Rigidbody rb in ragdollRigidbodies)
        {
            rb.isKinematic = !state;
            rb.detectCollisions = state;

            if (state)
            {
                rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Impulse);
            }
        }

        if (state && audioSource && ragdollSound)
        {
            audioSource.PlayOneShot(ragdollSound);
        }
    }

    /// <summary>
    /// Activates the ragdoll state with an optional force applied.
    /// </summary>
    public void ActivateRagdoll()
    {
        SetRagdollState(true);
    }

    /// <summary>
    /// Resets the character to its initial state after a specified delay.
    /// </summary>
    /// <param name="delay">The delay in seconds before resetting.</param>
    /// <returns></returns>
    private IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ResetToIdle();
    }

    /// <summary>
    /// Resets the character to its initial position, rotation, and animator state, deactivating the ragdoll.
    /// </summary>
    public void ResetToIdle()
    {
        SetRagdollState(false);
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
}
