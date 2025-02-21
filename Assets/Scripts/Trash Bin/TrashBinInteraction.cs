using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TrashBinInteraction : MonoBehaviour
{
    public TextMeshProUGUI tooltipText; 
    public GameObject vase;
    public GameObject hammer;
    public AudioSource canDropSound;
    private bool canThrown = false; 
    private float timer = 0f; 
    public Button tapButton;

    void Start()
    {
        vase.SetActive(false); 
        hammer.SetActive(false); 
    //    tapButton.interactable = false;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the bin is "cola"
        if (other.CompareTag("cola"))
        {
            ShowTooltip("Find another cola!");
            canThrown = true;
            PlaySound();
        }

        // When cola1 is found, reveal the vase
        if (other.CompareTag("cola1"))
        {
            Debug.Log("cola1 found!");
            ShowTooltip("Next clue: Take a cup of water and pour it on the planter.");
            vase.SetActive(true);
            // tapButton.interactable = true;
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
