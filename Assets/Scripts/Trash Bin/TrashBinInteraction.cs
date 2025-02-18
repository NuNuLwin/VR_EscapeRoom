using UnityEngine;
using TMPro;

public class TrashBinInteraction : MonoBehaviour
{
    public TextMeshProUGUI tooltipText; 
    public GameObject vase;
    private bool canThrown = false; 
    private float timer = 0f; 

    void Start()
    {
        vase.SetActive(false); 
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the bin is "cola"
        if (other.CompareTag("cola"))
        {
            ShowTooltip("Find another cola!");
            canThrown = true;
        }

        // When cola1 is found, reveal the vase
        if (other.CompareTag("cola1"))
        {
            Debug.Log("cola1 found!");
            ShowTooltip("Next clue: Vase.");
            vase.SetActive(true);
            canThrown = true;
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
}
