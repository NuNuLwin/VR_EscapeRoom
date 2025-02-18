using UnityEngine;

public class BreakableVase : MonoBehaviour
{
    public Rigidbody rb;
    private bool isBroken = false;

    void Start()
    {
        Debug.Log("start breaking");
        rb = GetComponent<Rigidbody>(); // Ensure rb is assigned
        rb.isKinematic = true; // Prevent movement until broken
    }

    void OnTriggerEnter(Collider other)
    {
       
         Debug.Log("OnTriggerEnter");
         Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Breaker"))
        {
         
         Debug.Log("hello.."+ isBroken);
            isBroken = true;
            rb.isKinematic = false; // Enable physics on the broken vase
            Invoke("DestroyPiece", 3f); // Destroy after 3 seconds
        }
    }

   void DestroyPiece()
{
    Debug.Log(gameObject.name + " is destroyed.");
    Destroy(gameObject);
}

}
