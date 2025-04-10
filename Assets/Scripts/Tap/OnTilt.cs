/*
 * OnTilt.cs
 * 
 * Description:
 * This script monitors the tilt of a GameObject (cup) and triggers events and actions when the object tilts past a specified threshold.
 * Reference: VR room Untiy
 */

using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class OnTilt : MonoBehaviour
{

    // The threshold for the tilt detection (0 to 1)
    [Range(0, 1)] public float threshold = 0.0f;

    [Serializable] public class TiltEvent : UnityEvent<MonoBehaviour> { }

     // Event triggered when the tilt exceeds the threshold
    public TiltEvent OnBegin = new TiltEvent();

    // Event triggered when the tilt is no longer exceeding the threshold
    public TiltEvent OnEnd = new TiltEvent();

    // Internal flags to track the tilt state
    private bool withinThreshold = false;
    private bool hasPlayedNarrative = false;

    // GameObjects to be activated when the tilt condition is met
    public GameObject hammer;  
    public GameObject vase;  
    public GameObject pourwaterParticle;
    public GameObject plant; 
    public TextMeshProUGUI paperText; 

    // Audio sources for sound effects 
    public AudioSource foundObjSound;
    public AudioSource waterSound;
    public AudioSource narrative;

    private void Update()
    {
        CheckOrientation();
    }

    // Method to check the current tilt of the GameObject
    private void CheckOrientation()
    {
        // Calculate the similarity between the object’s orientation and upright position
        float similarity = Vector3.Dot(-transform.up, Vector3.up);
        similarity = Mathf.InverseLerp(-1, 1, similarity);

        // Check if the tilt has exceeded the threshold
        bool thresholdCheck = similarity >= threshold;

         // If the tilt state has changed, trigger the corresponding events
        if (withinThreshold != thresholdCheck)
        {
            withinThreshold = thresholdCheck;

            if (withinThreshold)
            {
                // Play the water sound and invoke the OnBegin event
                PlayWaterSound();
                OnBegin.Invoke(this);
            }
            else
            {
                // Stop the water sound and invoke the OnEnd event
                StopWaterSound();
                OnEnd.Invoke(this);
            }

            // Activate the hammer object when the tilt is detected
            if (hammer != null)
            {
                hammer.SetActive(true);
            }

            // Play the sound effect and narrative once when the tilt starts
            PlaySound();
           
            // Activate the vase and text UI elements when the tilt condition is met
            if (vase != null)
            {
                vase.SetActive(true);
                paperText.gameObject.SetActive(true);
            }
        }
    }

    // Play the sound for finding an object and the narrative if not already played
    void PlaySound()
    {
        if (foundObjSound != null)
        {
            foundObjSound.Play();
            if (!hasPlayedNarrative && narrative != null) 
            {
                narrative.Play();
                hasPlayedNarrative = true;
            }
        }
    }

    // Play the water sound when the tilt exceeds the threshold
    void PlayWaterSound()
    {
        if (waterSound != null)
        {
            waterSound.Play();
        }
    }
    // Stop the water sound when the tilt no longer exceeds the threshold
    void StopWaterSound()
    {
        if (waterSound != null)
        {
            waterSound.Stop();
        }
    }

}
