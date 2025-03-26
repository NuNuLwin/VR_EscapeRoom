using UnityEngine;

public class OpenNoteBook: MonoBehaviour
{
     public GameObject Cover;
    public HingeJoint myHinge;
    public bool isLastBook;
    private AudioSource audioSource;
    private bool hasPlayedNarrative = false;
    public AudioClip lastBookNarrative; 
    
    void Start(){
        var myHinge = Cover.GetComponent<HingeJoint>();
        myHinge.useMotor  = false;

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void OpenSesame(){
         myHinge.useMotor  = true;
         if (isLastBook && !hasPlayedNarrative && lastBookNarrative != null)
        {
            audioSource.PlayOneShot(lastBookNarrative);
            hasPlayedNarrative = true;
        }
    }
}
