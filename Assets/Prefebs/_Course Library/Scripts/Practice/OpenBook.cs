using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Cover;
    public HingeJoint myHinge;
    void Start()
    {
        var myHinge = Cover.GetComponent<HingeJoint>();
        myHinge.useMotor = false;
    }

    public void OpenSesame(){
        myHinge.useMotor = true;
        Debug.Log("motot should be true");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
