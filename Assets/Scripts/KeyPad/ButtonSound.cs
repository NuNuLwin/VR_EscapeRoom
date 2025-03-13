using UnityEngine;
using UnityEngine.UI;  // Required for accessing UI Button
using UnityEngine.Events;

public class ButtonSound: MonoBehaviour
{
    public Button key1;         // Reference to your button
    public Button key2;  
    public Button key3;  
    public Button key4;  
    public Button key5;  
    public Button key6;  
    public Button key7;  
    public Button key8;  
    public Button key9;  
    public Button execute;  

    public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip buttonSound;   // The sound to play when the button is clicked

    void Start()
    {
        // Ensure there's an AudioSource and AudioClip assigned
        audioSource = GetComponent<AudioSource>();
        if ( buttonSound == null)
        {
            Debug.LogError("AudioSource or AudioClip is missing.");
            return;
        }

        // Add a listener to the button to play sound when clicked
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

    // Function to play the sound when the button is clicked
    void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSound); // Play the sound
    }
}
