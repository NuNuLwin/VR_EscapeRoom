using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; 

public class SafeOpenSound: MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioSource narrative;

     void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
    }

     void PlayDoorOpenSound()
    {
       audioSource.Play();
       narrative.Play();
    }
}
