/*
 * trigger.cs
 * 
 * Description:
 * This script handles the triggering of UnityEvents when objects with a specific tag (cola)
 * enter the trigger zone of the object (Trash bin) this script is attached to. The script uses 
 * a `UnityEvent<GameObject>` to invoke an action when a specified tagged object enters.
 */
using UnityEngine;
using UnityEngine.Events;
    
public class trigger : MonoBehaviour
{

    public string TagTarget;
    public UnityEvent<GameObject> onEnter;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag== TagTarget){
            // Invoke the UnityEvent and pass the colliding GameObject
            onEnter.Invoke(other.gameObject);
        }
    }
}
