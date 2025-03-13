using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; 

public class BackDoorOpenSound: MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component

     void Start()
    {
        // Ensure there's an AudioSource and AudioClip assigned
        audioSource = GetComponent<AudioSource>();
    }

     void PlayDoorOpenSound()
    {
       audioSource.Play();
    }
}
