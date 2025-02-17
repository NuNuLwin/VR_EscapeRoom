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
