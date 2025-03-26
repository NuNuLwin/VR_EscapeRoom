using System;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class OnTilt : MonoBehaviour
{

    [Range(0, 1)] public float threshold = 0.0f;

    [Serializable] public class TiltEvent : UnityEvent<MonoBehaviour> { }

    // Threshold has been broken
    public TiltEvent OnBegin = new TiltEvent();

    // Threshold is no longer broken
    public TiltEvent OnEnd = new TiltEvent();

    private bool withinThreshold = false;
    private bool hasPlayedNarrative = false;

     public GameObject hammer;  
     public GameObject vase;  
    public GameObject pourwaterParticle;
    public GameObject plant; 
    public TextMeshProUGUI paperText;  
    public AudioSource foundObjSound;
    public AudioSource waterSound;
    public AudioSource narrative;

    private void Update()
    {
        CheckOrientation();
    }

    private void CheckOrientation()
    {
        float similarity = Vector3.Dot(-transform.up, Vector3.up);
        similarity = Mathf.InverseLerp(-1, 1, similarity);

        bool thresholdCheck = similarity >= threshold;

        if (withinThreshold != thresholdCheck)
        {
            withinThreshold = thresholdCheck;

            if (withinThreshold)
            {
                PlayWaterSound();
                OnBegin.Invoke(this);
            }
            else
            {
                StopWaterSound();
                OnEnd.Invoke(this);
            }

            if (hammer != null)
            {
                hammer.SetActive(true);
            }

            PlaySound();
           

            if (vase != null)
            {
                vase.SetActive(true);
                paperText.gameObject.SetActive(true);
            }
        }
    }

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

    void PlayWaterSound()
    {
        if (waterSound != null)
        {
            waterSound.Play();
        }
    }
    void StopWaterSound()
    {
        if (waterSound != null)
        {
            waterSound.Stop();
        }
    }

}
