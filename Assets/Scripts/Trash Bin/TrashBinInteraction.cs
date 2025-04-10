/*
 * TrashBinInteraction.cs
 * 
 * Description:
 * This script handles interactions between the player and the trash bin in a game. 
 * It displays tooltips with messages when cola cans are picked up, plays sound effects, 
 * and manages a timer for UI clue.
 * The script also interacts with buttons and other game objects related to the interaction.
 */
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
    public GameObject cup;

    void OnTriggerEnter(Collider other)
    {
        narrative.Stop();
        narrative2.Stop();
   
        // Check if the object entering the trigger zone is tagged as "cola"
        if (other.CompareTag("cola"))
        {
            ShowTooltip("Cola 1 of 2. \nFind the second one where water falls from above.");
            narrative.Play();                           // Play the first narrative audio
            PlaySound();                                // Play the cola can drop sound
            cola1.SetActive(true);                      // Show the first cola can
        }
        
         // Check if the object entering the trigger zone is tagged as "cola1"
        if (other.CompareTag("cola1"))
        {
            ShowTooltip("Cola 2 of 2. \nNext clue: Make the shortest planter wet!");
            narrative2.Play();
            tapButton.gameObject.SetActive(true);       // Show the tap button for further interaction
            cup.gameObject.SetActive(true);             // Show the cup object for interaction
            canThrown = true;
            PlaySound();                                // Play the cola can drop sound
        }
    }

    void Update()
    {
        // Handle logic for throwing action if the flag is set
        if (canThrown)
        {
            timer += Time.deltaTime;
            if (timer > 20f)        // If 20 seconds have passed, reset hideToolTip
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

    // Play the cola drop sound if it's assigned
    void PlaySound()
    {
        if (canDropSound != null)
        {
            canDropSound.Play();
        }
    }
}
