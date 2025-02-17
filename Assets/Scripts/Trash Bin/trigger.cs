using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class trigger : MonoBehaviour
{
    // Start is called before the first frame update

    public string TagTarget;
    public UnityEvent<GameObject> onEnter;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== TagTarget){
            onEnter.Invoke(other.gameObject);
        }
    }
}
