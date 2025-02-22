using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TapControl : MonoBehaviour
{
    public ParticleSystem waterStream; 
    public ParticleSystem cupWater; 
    
    public Button tapButton;
    public TextMeshProUGUI buttonText;
    public AudioSource waterSound;

    private bool isTapOpen = false; 

    void Start()
    {
       
        waterStream.Stop();
        cupWater.Stop();

        tapButton.onClick.AddListener(WaterFlow);

        UpdateButtonLabel();
    }

    public void WaterFlow()
    {
        isTapOpen = !isTapOpen; 

        if (isTapOpen)
        {
            PlaySound();
            waterStream.Play(); 
            cupWater.Play();
        }
        else
        {

            waterStream.Stop(); 
            StopSound();

        }

        UpdateButtonLabel();
    }

    void UpdateButtonLabel()
    {
        buttonText.text = isTapOpen ? "Close Tap" : "Open Tap";
    }
    void PlaySound()
    {
        if (waterSound != null)
        {
            waterSound.Play();
        }
    }
    void StopSound()
    {
        if (waterSound != null)
        {
            waterSound.Stop();
        }
    }
    
}
