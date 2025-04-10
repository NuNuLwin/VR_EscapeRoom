/*
 * Trash.cs
 * 
 * Description:
 * The Trash script disables cola can GameObject when it enters its trigger zone.
 * It listens to the 'onEnter' event from a custom 'trigger' component to detect when an object enters the trigger.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{ 
    public void Start()
    {
      GetComponent<trigger>().onEnter.AddListener(InsideTrash);
    }
    public void InsideTrash(GameObject gameobject){
        gameObject.SetActive(false);
    }
   
}
