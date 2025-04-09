/*
 * OpenNoteBook.cs
 * 
 * Description:
 * This script handles the interaction for opening a notebook (or book cover) using a hinge joint.
 * It optionally plays a narrative audio clip if the book is the last in a sequence. This is designed 
 * for use in a 3D environment with physics-based book opening.
 * 
 */
using UnityEngine;

public class OpenNoteBook: MonoBehaviour
{
     public GameObject Cover;                   // The cover GameObject with a HingeJoint
    public HingeJoint myHinge;                  // HingeJoint component that controls book movement
    public bool isLastBook;                     // Flag to indicate if this is the last book
    private AudioSource audioSource;            // Audio source to play sounds
    private bool hasPlayedNarrative = false;    // Ensure the narrative plays only once
    public AudioClip lastBookNarrative;         // Optional audio clip for narrative
    
    void Start(){
        // Get the HingeJoint from the cover object
        var myHinge = Cover.GetComponent<HingeJoint>();
        myHinge.useMotor  = false;  // Disable motor until triggered

        // Get or add an AudioSource component to the book
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    // Call this method to open the book and play narrative
    public void OpenSesame(){
        myHinge.useMotor  = true;  // Enable the motor to open the book

        // Play narrative only if this is the last book and the audio hasn't been played yet
        if (isLastBook && !hasPlayedNarrative && lastBookNarrative != null)
        {
            audioSource.PlayOneShot(lastBookNarrative);
            hasPlayedNarrative = true;
        }
    }
}
