using UnityEngine;

public class OpenNoteBook: MonoBehaviour
{
     public GameObject Cover;
    public HingeJoint myHinge;
    
    void Start(){
        var myHinge = Cover.GetComponent<HingeJoint>();
        myHinge.useMotor  = false;
    }

    public void OpenSesame(){
         myHinge.useMotor  = true;
    }
}
