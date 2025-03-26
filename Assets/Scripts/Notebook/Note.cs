using UnityEngine;

public class Note : MonoBehaviour
{
    public AudioSource narrative;

    void Start()
    {
        
        narrative = GetComponent<AudioSource>();
        PlayNarrative();

    }
    void PlayNarrative()
    {
        narrative.Play();
    }
}
