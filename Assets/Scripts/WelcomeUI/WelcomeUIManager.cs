using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using System.Collections;
using UnityEngine.UI;

public class WelcomeUIManager : MonoBehaviour
{
    public GameObject welcomeUI; 
    public TextMeshProUGUI timerText; 
    public TextMeshProUGUI welcomeText; 
    public Button okButton;
    public AudioSource countdownSound;

    private float countdownTime = 60f; // 5 minutes (300 seconds)
    private bool isTimerRunning = false;

    void Start()
    {
  
        timerText.gameObject.SetActive(false); // Hide timer initially
    }

    public void OnOkButtonClicked()
    {
        // welcomeUI.SetActive(false); // Disable Welcome UI
        okButton.gameObject.SetActive(false);
        welcomeText.gameObject.SetActive(false); // Disable Welcome Text
        timerText.gameObject.SetActive(true); // Show Timer
        // Start Countdown Sound
        if (countdownSound != null)
        {
            countdownSound.Play();
        }
        StartCoroutine(StartCountdown()); // Start Timer
    }

    private IEnumerator StartCountdown()
    {
        isTimerRunning = true;

        while (countdownTime > 0)
        {
            int minutes = Mathf.FloorToInt(countdownTime / 60);
            int seconds = Mathf.FloorToInt(countdownTime % 60);
            timerText.text = "Time Remaining: " + string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        // Stop Countdown Sound
        if (countdownSound != null)
        {
            countdownSound.Stop();
        }

        timerText.text = "Game Over"; // Timer ends
        isTimerRunning = false;
    }
}
