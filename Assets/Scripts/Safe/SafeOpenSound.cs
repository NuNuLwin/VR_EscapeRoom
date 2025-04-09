/*
 * SafeOpenSound.cs
 * 
 * Description:
 * This script controls the sound effects for opening a safe (or similar object). It plays both 
 * the door opening sound and a narrative sound when triggered. This script is intended for use 
 * in a 3D environment where a safe or container's opening sound and associated narrative are played 
 * simultaneously.
 * 
 */
using UnityEngine;

public class SafeOpenSound: MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioSource narrative;

     void Start()
    {
        // Ensure an AudioSource is assigned to the main sound (safe opening sound)
        audioSource = GetComponent<AudioSource>();
    }

    // Function to play both the door opening sound and the narrative sound
     void PlayDoorOpenSound()
    {
       audioSource.Play();       // Play the safe opening sound
       narrative.Play();         // Play the associated narrative sound
    }
}
