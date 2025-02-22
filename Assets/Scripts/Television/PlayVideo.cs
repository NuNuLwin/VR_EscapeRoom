using UnityEngine;
using UnityEngine.Video;


[RequireComponent(typeof(VideoPlayer))]
public class PlaySingleVideo : MonoBehaviour
{
   
    public bool playAtStart = false;

    public Material videoMaterial = null;

    public VideoClip videoClip;

    private VideoPlayer videoPlayer;
    private MeshRenderer meshRenderer;

    public GameObject cola; 

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
        videoMaterial.color = Color.white;
        videoPlayer.Play();

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

    

}
