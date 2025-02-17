using UnityEngine;
using TMPro;

public class TrashBinInteraction : MonoBehaviour
{
    public TextMeshProUGUI tooltipText; 
    private bool canThrown = false; 
    private float timer = 0f; 

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the bin is the can
        if (other.CompareTag("cola"))
        {
            // Show tooltip
            ShowTooltip("Find another cola!");
            canThrown = true;
        }
        if (other.CompareTag("cola1"))
        {
            // Show tooltip
            Debug.Log("OnTriggerEnter");
            ShowTooltip("Next clue: Fruit.");
            canThrown = true;
        }
    }

    void Update()
    {
        // If the can was thrown and tooltip is shown, start a timer to hide it
        if (canThrown)
        {
            timer += Time.deltaTime;
            if (timer > 10f) // Hide after 3 seconds
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
        tooltipText.gameObject.SetActive(true); // Show the tooltip
    }

    // Hide the tooltip text
    void HideTooltip()
    {
        tooltipText.gameObject.SetActive(false); // Hide the tooltip
    }
}
