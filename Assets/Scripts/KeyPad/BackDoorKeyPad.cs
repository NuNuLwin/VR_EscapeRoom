/*
 * BackDoorKeyPad.cs
 * 
 * Description:
 * This script manages a numeric keypad interface for unlocking a back door using a passcode.
 * It handles user input, compares it to the correct answer, plays an animation if the code is correct, 
 * and displays a congratulatory message using a canvas.
 * 
 */

using UnityEngine;
using TMPro; 

public class BackDoorKeyPad: MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI displayText;   // UI text field for showing input and messages
    private string Answer = "8944";                         // Correct code

    [SerializeField] private Animator _anim;                // Animator to trigger door opening animation
     public GameObject exitCanvas;                          // Canvas that appears after correct input


    // Called when a number button is pressed
    public void Number(int number){
        displayText.text += number.ToString();
    }

    // Called when the execute/enter button is pressed
    public void Execute(){
        if(displayText.text == Answer){
            displayText.text = "Correct";
             _anim.SetTrigger("Open_Back_Door");    // Trigger the door-opening animation
            Invoke("showCongratulationMsg", 1f);    // Delay before showing congratulatory canvas
            
        }else{
            displayText.text = "Invalid";           
            displayText.text = "";
        }
    }

    // Activates the congratulatory canvas after a delay
    void showCongratulationMsg(){
        exitCanvas.SetActive(true);
    }
}
