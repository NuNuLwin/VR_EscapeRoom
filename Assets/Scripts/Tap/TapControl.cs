/*
 * TapControl.cs
 * 
 * Description:
 * This script controls the behavior of a tap system, allowing the user to open and close the tap to control water flow. 
 * When the tap is opened, a water stream particle effect plays, a cup fills with water, and a sound is played.
 * The tap button text toggles between "Open Tap" and "Close Tap" based on the tap's state.
 */
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TapControl : MonoBehaviour
{
    // Particle systems for water effects
    public ParticleSystem waterStream; 
    public ParticleSystem cupWater; 
    
    // UI elements
    public Button tapButton;
    public TextMeshProUGUI buttonText;
    public AudioSource waterSound;

    private bool isTapOpen = false; 

    void Start()
    {
        // Stop water effects initially
        waterStream.Stop();
        cupWater.Stop();

        // Add the WaterFlow function to the button click event
        tapButton.onClick.AddListener(WaterFlow);

        // Update the button label to reflect the tap state
        UpdateButtonLabel();
    }

    // Method to toggle the tap state (open/close) and trigger appropriate actions
    public void WaterFlow()
    {
        isTapOpen = !isTapOpen;         // Toggle the state of the tap

        // If the tap is open, play water effects and sound
        if (isTapOpen)
        {
            PlaySound();
            waterStream.Play();         // Start the water stream particle effect
            cupWater.Play();            // Start filling the cup with water
        }
        else
        {
            // If the tap is closed, stop water effects and sound
            waterStream.Stop();         // Stop the water stream particle effect
            StopSound();                // Stop the water sound

        }

        // Update the button label based on the tap state
        UpdateButtonLabel();
    }

    // Method to update the button label (text) based on the tap state
    void UpdateButtonLabel()
    {
        // Set the button text to "Close Tap" if the tap is open, "Open Tap" if the tap is closed
        buttonText.text = isTapOpen ? "Close Tap" : "Open Tap";
    }

    // Method to play the water sound effect
    void PlaySound()
    {
        if (waterSound != null)
        {
            waterSound.Play();      // Play the water sound
        }
    }

    // Method to stop the water sound effect
    void StopSound()
    {
        if (waterSound != null)
        {
            waterSound.Stop();      // Stop the water sound
        }
    }
    
}
