using UnityEngine;

public class SteamManager : MonoBehaviour
{
    public ParticleSystem cupSteam; // Reference to the cup steam particle system

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SteamParticle")) // Check if the object is a steam particle
        {
            // Increase cup steam emission
            var emission = cupSteam.emission;
            emission.rateOverTime = Mathf.Clamp(emission.rateOverTime.constant + 5, 10, 50);
        }
    }
}
