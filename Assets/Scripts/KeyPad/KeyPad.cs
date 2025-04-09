/*
 * KeyPad.cs
 * 
 * Description:
 * This script controls a keypad puzzle interaction. Users input digits via UI buttons, and when they
 * press the "Execute" button, the script checks whether the entered code matches the correct answer.
 * If the answer is correct, it triggers an animation and reveals an game object (e.g., a note).
 * 
 */

using UnityEngine;
using TMPro; 

public class KeyPad: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText; // Text field showing input digits
    private string Answer = "9632";                       // Correct answer to unlock

    [SerializeField] private Animator _anim;              // Animator to control safe/door opening

    public GameObject bathroomNote;                      // Object to display on correct input

    void Start()
    {
        // Ensure the note is hidden at the start
        bathroomNote.SetActive(false);
    }

    // Appends the pressed number to the display text
    public void Number(int number){
        displayText.text += number.ToString();
    }

    // Checks the entered code when "Execute" is pressed
    public void Execute(){
        if(displayText.text == Answer){
            displayText.text = "Correct";
           
            // Trigger the safe opening animation
             _anim.SetTrigger("OpenSafe");

            // Reveal the hidden note or object
            bathroomNote.SetActive(true);
        }else{
            displayText.text = "Invalid";
            displayText.text = "";
        }
    }
}
