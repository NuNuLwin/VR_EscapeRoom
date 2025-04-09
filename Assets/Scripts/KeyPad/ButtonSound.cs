/*
 * ButtonSound.cs
 * 
 * Description:
 * This script enables audio feedback for a keypad-style UI. It assigns a click sound 
 * to each numbered button and an execute button. When any of these buttons are clicked, 
 * a predefined sound is played using an AudioSource.
 * 
 */


using UnityEngine;
using UnityEngine.UI; 

public class ButtonSound: MonoBehaviour
{
    // UI Button references for each keypad key and the execute button
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

    // Audio source and clip used for playing button sounds
    public AudioSource audioSource; 
    public AudioClip buttonSound;   

    void Start()
    {
        // Get the AudioSource component from the current GameObject
        audioSource = GetComponent<AudioSource>();

        // Error check: Ensure that a button sound is assigned
        if ( buttonSound == null)
        {
            Debug.LogError("AudioSource or AudioClip is missing.");
            return;
        }

        // Register the PlayButtonSound method to be called when each button is clicked
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

    // This method plays the assigned button sound once using the AudioSource
    void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound); 
    }
}
