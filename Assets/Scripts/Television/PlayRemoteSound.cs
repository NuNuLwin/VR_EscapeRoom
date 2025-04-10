/*
 * PlayRemoteSound.cs
 * 
 * Description:
 * This script plays a remote control sound when triggered (for example, when a button is pressed or an event occurs).
 * It uses the `AudioSource` component to play an `AudioClip` at a specified volume.
 * The audio is played only once per trigger using the `PlayOneShot` method.
 * This script also ensures that the audio does not play automatically when the game starts by setting `playOnAwake` to `false`.
 */
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayRemoteSound : MonoBehaviour
{
    public AudioClip sound = null;
  
    public float volume = 1.0f;

    private AudioSource audioSource = null;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        // Play the sound once at the specified volume using PlayOneShot
        audioSource.PlayOneShot(sound, volume);
    }

    // Called when the script is validated in the Unity Editor
    private void OnValidate()
    {
        // Prevent the audio from playing automatically on start
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }
}
