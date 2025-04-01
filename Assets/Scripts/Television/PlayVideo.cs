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

    private void OnEnable()
    {
        videoPlayer.prepareCompleted += ApplyVideoMaterial;
    }

    private void OnDisable()
    {
        videoPlayer.prepareCompleted -= ApplyVideoMaterial;
    }

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

    public void Play()
    {
        if (videoClip == null) return;
        playTV = true;
        videoMaterial.color = Color.white;
        videoPlayer.Play();
        ShowTooltip("This isn’t just an ad...\nIt’s your way out.\nLook closer.\nThe product logo— that’s your next clue.");

        // Enable Cola Can: Second Task
        cola.SetActive(true);
    }

    public void Stop()
    {
        videoMaterial.color = Color.black;
        videoPlayer.Stop();
    }

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


 // Show the tooltip text
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
