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



    void OnTriggerEnter(Collider other)
    {
   
        if (other.CompareTag("cola"))
        {
            ShowTooltip("Find another cola!");
            canThrown = true;
            PlaySound();
            cola1.SetActive(true);
        }
        
        if (other.CompareTag("cola1"))
        {
            ShowTooltip("Next clue: Take a cup of water and pour it on the planter.");
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
            if (timer > 10f) 
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
