using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TapControl : MonoBehaviour
{
    public ParticleSystem waterStream; 
    // public ParticleSystem cupWater;
    public Button tapButton;
    public TextMeshProUGUI buttonText;

    private bool isTapOpen = true; 

    void Start()
    {
       
        // waterStream.Stop();
        // cupWater.Stop();

        tapButton.onClick.AddListener(WaterFlow);

        UpdateButtonLabel();
    }

    public void WaterFlow()
    {
       Debug.Log("Water flow triggered");
        isTapOpen = !isTapOpen; 

        if (isTapOpen)
        {
            waterStream.Play(); 
            //  StartCoroutine(FillCupWater());
        }
        else
        {
            waterStream.Stop(); 
            // cupWater.Stop();
        }

        UpdateButtonLabel();
    }

    // IEnumerator FillCupWater()
    // {
    //     yield return new WaitForSeconds(1); // Small delay before cup fills
    //     cupWater.Play();
    // }

    void UpdateButtonLabel()
    {
        buttonText.text = isTapOpen ? "Close Tap" : "Open Tap";
    }
}
