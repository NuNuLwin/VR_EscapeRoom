using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrashBinInteraction : MonoBehaviour
{
    public TextMeshProUGUI tooltipText; 
    public GameObject cola1;
    public AudioSource canDropSound;
    private bool canThrown = false; 
    private float timer = 0f; 
    public Button tapButton;
    public AudioSource narrative; 
    public AudioSource narrative2; 



    void OnTriggerEnter(Collider other)
    {
        narrative.Stop();
        narrative2.Stop();
   
        if (other.CompareTag("cola"))
        {
            ShowTooltip("Cola 1 of 2. \nFind the second one where water falls from above.");
            narrative.Play();
            // canThrown = true;
            PlaySound();
            cola1.SetActive(true);
        }
        
        if (other.CompareTag("cola1"))
        {
            ShowTooltip("Cola 2 of 2. \nNext clue: Make the shortest planter wet!");
            narrative2.Play();
            tapButton.gameObject.SetActive(true); 
            canThrown = true;
            PlaySound();
        }
    }

    void Update()
    {
        
        if (canThrown)
        {
            timer += Time.deltaTime;
            if (timer > 20f) 
            {
                HideTooltip();
                canThrown = false;
                timer = 0f;
            }
        }
    }

    // Show the tooltip text
    void ShowTooltip(string message)
    {
        tooltipText.text = message;
        tooltipText.gameObject.SetActive(true); 
    }

    // Hide the tooltip text
    void HideTooltip()
    {
        tooltipText.gameObject.SetActive(false); 
    }

    void PlaySound()
    {
        if (canDropSound != null)
        {
            canDropSound.Play();
        }
    }
}
