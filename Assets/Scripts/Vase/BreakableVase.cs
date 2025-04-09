/*
 * BreakableVase.cs
 * 
 * Description:
 * This script manages the behavior of a breakable vase object.
 * When a collider tagged as "Breaker" interacts with the vase, the vase will "break" by becoming non-kinematic,
 * allowing physics to take over. Additionally, a crash sound will play upon breaking.
 * The vase can optionally be destroyed after a brief delay.
 */

using UnityEngine;

public class BreakableVase : MonoBehaviour
{
    public Rigidbody rb;
    private bool isBroken = false;
    public AudioSource crashSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();     // Get the Rigidbody component attached to this object
        rb.isKinematic = true;              // Set the Rigidbody to be kinematic initially (no physics interactions)
    }

    void OnTriggerEnter(Collider other)
    {
       
        // If the object colliding with the vase has the tag "Breaker"
        if (other.gameObject.CompareTag("Breaker"))
        {
            isBroken = true;
            rb.isKinematic = false;         // Disable kinematic mode to enable physics interactions (vase breaks)
             PlayCrashSound();              // Play the crash sound
        }
    }

    void PlayCrashSound()
    {
        if (crashSound != null)
        {
            crashSound.Play();               // Play the crash sound
        }
    }

}
