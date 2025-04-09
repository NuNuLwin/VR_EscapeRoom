/*
 * BackDoorButtonSound.cs
 * 
 * Description:
 * This script is used to assign and play a button click sound for a numeric keypad and an execute button in a Unity UI.
 * When any of the buttons (key1 to key9 or execute) is clicked, a specified audio clip is played through an AudioSource component.
 * 
 */
using UnityEngine;
using UnityEngine.UI;  

public class BackDoorButtonSound: MonoBehaviour
{
    // References to numeric keypad buttons and execute button
    public Button key1;
    public Button key2;  
    public Button key3;  
    public Button key4;  
    public Button key5;  
    public Button key6;  
    public Button key7;  
    public Button key8;  
    public Button key9;  
    public Button execute;  

    // Audio source and audio clip to play on button click
    public AudioSource audioSource; 
    public AudioClip buttonSound; 

    void Start()
    {
        // Attempt to retrieve the AudioSource if not already assigned
        audioSource = GetComponent<AudioSource>();
        if ( buttonSound == null)
        {
            Debug.LogError("AudioSource or AudioClip is missing.");
            return;
        }

        // Register click listeners for each button to trigger the sound
        key1.onClick.AddListener(PlayButtonSound);
        key2.onClick.AddListener(PlayButtonSound);
        key3.onClick.AddListener(PlayButtonSound);
        key4.onClick.AddListener(PlayButtonSound);
        key5.onClick.AddListener(PlayButtonSound);
        key6.onClick.AddListener(PlayButtonSound);
        key7.onClick.AddListener(PlayButtonSound);
        key8.onClick.AddListener(PlayButtonSound);
        key9.onClick.AddListener(PlayButtonSound);
        execute.onClick.AddListener(PlayButtonSound);
    }

    // Plays the assigned audio clip using the AudioSource
    void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
    }
}
