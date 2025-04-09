/*
 * WelcomeTextManager.cs
 * 
 * Description:
 * This script controls the sequence of events when the player enters the game.
 * The instructions are displayed in the welcome canvas UI. Once the player starts the game,
 * a 5-minute countdown timer begins.
 * The interactive game puzzles are hidden until the game starts.
 */

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
    public AudioSource narrative;  
    public AudioSource narrative2;  

    //Array of objects to be hidden before the game starts
    public GameObject[] objectsToHide; 
    private GameObject remote; 

    private bool isFirstMessage = true;
    private float timer = 300f;  //Timer set to 5 minutes (300 seconds)
    private bool isTimerRunning = false;

    void Start()
    {
     
        narrative.Play();                               // Start the introductory narrative audio
        nextButton.onClick.AddListener(ShowClueText);  
        okButton.onClick.AddListener(HandleOkButton);   // Add listener to the okButton to handle OK click
       
        okButton.gameObject.SetActive(false);           // Hide the OK button initially
        timerText.gameObject.SetActive(false);          // Hide the timer text initially

        // Hide all interactive objects before game start
        HideGameObject(); 

       // Find Remote in the objectsToHide array
        remote = FindRemote();
    }

    // Show the first clue when the nextButton is clicked
    void ShowClueText()
    {
        if (isFirstMessage)     // Check if this is the first message
        {
            narrative.Stop();   // Stop the first narrative audio
            narrative2.Play();  // Play the second narrative audio
            welcomeText.text = "You have 5 minutes to escape!\n\nSomething important is on the TV!\n\nGood luck!"; // Update the welcome text
            nextButton.gameObject.SetActive(false);   // Hide the nextButton
            okButton.gameObject.SetActive(true);      // Show the OK button
            isFirstMessage = false;                   // Set the flag to false so the first message won't show again
        }
    }

    void Update()
    {
        if (isTimerRunning)             // Check if the timer is running
        {
            timer -= Time.deltaTime;    // Decrease the timer by the time passed since last frame
            timerText.text = "Time remaining: " + FormatTime(timer);    // Update the timer text UI

            if (timer <= 0)             // If the timer reaches zero
            {
                timer = 0;              // Set the timer to zero
                isTimerRunning = false; // Stop the timer
                GameOver();             // Call the GameOver function
            }

        }
    }

    void HandleOkButton()
    {
        okButton.gameObject.SetActive(false);  
        welcomeText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(true);
        isTimerRunning = true;      // Start the timer

        if (timerAudio != null)
        {
            timerAudio.Play();      // Play the timer countdown audio
        }

        remote.SetActive(true);      //Enable Remote: First Clue

    }

    string FormatTime(float time)
    {
        // Format the time as MM:SS
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Called when the game is over (timer reaches zero)
    void GameOver()
    {
      
        if (timerAudio != null)
        {
            timerAudio.Stop();          // Stop the timer audio
        }

   
        timerText.text = "Game Over!"; // Display "Game Over" message on the timer UI
    }

    // Hide all objects in the objectsToHide array
    void HideGameObject(){
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);  // Set each object as inactive
        }  
    }

    GameObject FindRemote()     // Find the remote object in the objectsToHide array
    {
        foreach (GameObject obj in objectsToHide)
        {
            if (obj.name.ToLower().Contains("remote"))  // Check if the object's name contains "remote"
            {
                return obj;     // Return the remote object
            }
        }
        return null;            // Return null if no remote object is found
    }

}
