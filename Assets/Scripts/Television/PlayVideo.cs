/*
 * PlayVideo.cs
 * 
 * Description:
 * This script controls the playback of a cola ad video on a `VideoPlayer` component.
 * It allows the video to be played through user interaction. 
 * The video is displayed on a material applied to a mesh, and a tooltip with specific messages is shown during the video.
 * The script also enables a GameObject (like a cola can) after the video starts playing.
 */
using UnityEngine;
using UnityEngine.Video;
using TMPro;


[RequireComponent(typeof(VideoPlayer))]
public class PlaySingleVideo : MonoBehaviour
{
   
    public bool playAtStart = false;

    public Material videoMaterial = null;

    public VideoClip videoClip;

    private VideoPlayer videoPlayer;
    private MeshRenderer meshRenderer;

    public GameObject cola; 

    public TextMeshProUGUI tooltipText; 
    private float timer = 0f; 
     private bool playTV = false; 

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoClip != null)
            videoPlayer.clip = videoClip;
    }

    // Subscribe to the prepareCompleted event of the VideoPlayer to apply the material after the video is prepared
    private void OnEnable()
    {
        videoPlayer.prepareCompleted += ApplyVideoMaterial;
    }

    // Unsubscribe from the prepareCompleted event when the object is disabled
    private void OnDisable()
    {
        videoPlayer.prepareCompleted -= ApplyVideoMaterial;
    }

    // Start the video based on the playAtStart flag
    private void Start()
    {
        if (playAtStart)
        {
            Play();
        }
        else
        {
            Stop();
        }
    }

    // Method to start playing the video
    public void Play()
    {
        // If there is no video clip, return early
        if (videoClip == null) return;

        // Set flag to indicate that the TV is playing
        playTV = true;

        // Set the video material to be visible
        videoMaterial.color = Color.white;

        // Start playing the video
        videoPlayer.Play();

        // Show the tooltip message
        ShowTooltip("This isn’t just an ad...\nIt’s your way out.\nLook closer.\nThe product logo— that’s your next clue.");

        // Enable the Cola GameObject for the next task
        cola.SetActive(true);
    }

    // Method to stop the video and hide the video material
    public void Stop()
    {
        videoMaterial.color = Color.black;      // Set the video material to be invisible (black)
        videoPlayer.Stop();                     // Stop the video
    }

    // Toggle between playing and pausing the video
    public void TogglePlayPause()
    {
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();
        else
            Play();
    }

    private void ApplyVideoMaterial(VideoPlayer source)
    {
        meshRenderer.material = videoMaterial;
    }


    // Show the tooltip with the provided message
    void ShowTooltip(string message)
    {
        tooltipText.text = message;
        tooltipText.gameObject.SetActive(true); 
    }

    // Hide the tooltip text
    void HideTooltip()
    {
        tooltipText.gameObject.SetActive(false); 
    }

    // Update the timer and hide the tooltip after a specified time
    void Update()
    {
        
        if (playTV)
        {
            timer += Time.deltaTime;
            if (timer > 20f) 
            {
                HideTooltip();
                playTV = false;
                timer = 0f;
            }
        }
    }
    

}
