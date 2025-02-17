using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class KeyPad: MonoBehaviour
{
    //[SerializeField] private TextMeshProGUI displaytext;
     [SerializeField] private TextMeshProUGUI displayText; 
    private string Answer = "1234";

    [SerializeField] private Animator _anim;

    //  

    public void Number(int number){
        displayText.text += number.ToString();
    }
    public void Execute(){
        if(displayText.text == Answer){
            displayText.text = "Correct";
            //_anim.SetBool("OpenSafe",true);
             _anim.SetTrigger("OpenSafe");
        }else{
            displayText.text = "Invalid";
             displayText.text = "";
        }
    }
}
