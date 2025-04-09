/*
 * BackDoorOpenSound.cs
 * 
 * Description:
 * This script is responsible for playing audio when the back door opens. It plays a combination of 
 * door sound effects, a narrative voiceover, and a success sound. The `PlayDoorOpenSound()` method 
 * should be called (e.g., via an animation event or trigger) to play the sounds simultaneously.
 *
 */
using UnityEngine;

public class BackDoorOpenSound: MonoBehaviour
{
    public AudioSource audioSource;     // Door opening sound
    public AudioSource narrative;       // Narrative explanation
    public AudioSource successSound;    // Sound to indicate successful unlock

     void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Call this method to play all associated audio clips
    void PlayDoorOpenSound()
    {
       audioSource.Play();
       narrative.Play();
       successSound.Play();
    }
}
