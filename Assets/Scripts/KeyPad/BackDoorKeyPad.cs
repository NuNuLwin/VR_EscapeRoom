using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class BackDoorKeyPad: MonoBehaviour
{
    
     [SerializeField] private TextMeshProUGUI displayText; 
    private string Answer = "8944";

    [SerializeField] private Animator _anim;
     public GameObject exitCanvas; 


    public void Number(int number){
        displayText.text += number.ToString();
    }
    public void Execute(){
        if(displayText.text == Answer){
            displayText.text = "Correct";
            //_anim.SetBool("OpenSafe",true);
             _anim.SetTrigger("Open_Back_Door");
            Invoke("showCongratulationMsg", 2f);
            
        }else{
            displayText.text = "Invalid";
             displayText.text = "";
        }
    }

    void showCongratulationMsg(){
        exitCanvas.SetActive(true);
    }
}
