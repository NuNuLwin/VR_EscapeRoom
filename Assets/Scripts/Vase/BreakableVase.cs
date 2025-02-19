using UnityEngine;

public class BreakableVase : MonoBehaviour
{
    public Rigidbody rb;
    private bool isBroken = false;
    public AudioSource crashSound;

    void Start()
    {
        Debug.Log("start breaking");
        rb = GetComponent<Rigidbody>(); 
        rb.isKinematic = true; 
    }

    void OnTriggerEnter(Collider other)
    {
       
         Debug.Log("OnTriggerEnter");
         Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Breaker"))
        {
            isBroken = true;
            rb.isKinematic = false; 
             PlayCrashSound();
            // Invoke("DestroyPiece", 3f); // Destroy after 3 seconds
        }
    }

   void DestroyPiece()
    {
        Debug.Log(gameObject.name + " is destroyed.");
        Destroy(gameObject);
    }

    void PlayCrashSound()
    {
        if (crashSound != null)
        {
            crashSound.Play(); 
        }
    }

}
