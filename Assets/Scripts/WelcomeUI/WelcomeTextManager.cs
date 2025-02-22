using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WelcomeTextManager : MonoBehaviour
{
    public TextMeshProUGUI welcomeText;  
    public Button nextButton;           
    public Button okButton;     
    public TextMeshProUGUI timerText;  
    public AudioSource timerAudio;       

    private bool isFirstMessage = true;
    private float timer = 300f; 
    private bool isTimerRunning = false;

    void Start()
    {
        nextButton.onClick.AddListener(ShowClueText);  
        okButton.onClick.AddListener(HandleOkButton); 
        okButton.gameObject.SetActive(false);  
        timerText.gameObject.SetActive(false);         
    }

    void ShowClueText()
    {
        if (isFirstMessage)
        {
            welcomeText.text = "You have 5 minutes to escape!\n\nYour first clue is: Watch TV.\n\nGood luck!";
            nextButton.gameObject.SetActive(false);   
            okButton.gameObject.SetActive(true);    
            isFirstMessage = false;
        }
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timer -= Time.deltaTime; 
            timerText.text = "Time remaining: " + FormatTime(timer);

            if (timer <= 0)
            {
                timer = 0;  
                isTimerRunning = false;
                GameOver();
               
            }

        }
    }

    void HandleOkButton()
    {
        okButton.gameObject.SetActive(false);  
        welcomeText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);
        isTimerRunning = true;

        if (timerAudio != null)
        {
            timerAudio.Play();
        }
    }

    string FormatTime(float time)
    {
        // Format the time as MM:SS
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
      
        if (timerAudio != null)
        {
            timerAudio.Stop();
        }

   
        timerText.text = "Game Over!";
    }

}
