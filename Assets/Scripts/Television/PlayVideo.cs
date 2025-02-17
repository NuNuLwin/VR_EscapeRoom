using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Plays a single video on a specified material.
/// </summary>
[RequireComponent(typeof(VideoPlayer))]
public class PlaySingleVideo : MonoBehaviour
{
    [Tooltip("Whether video should play on load")]
    public bool playAtStart = false;

    [Tooltip("Material used for playing the video (Uses URP/Unlit by default)")]
    public Material videoMaterial = null;

    [Tooltip("Video clip to play")]
    public VideoClip videoClip;

    private VideoPlayer videoPlayer;
    private MeshRenderer meshRenderer;

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

    // private void OnValidate()
    // {
    //     if (videoMaterial == null)
    //     {
    //         videoMaterial = new Material(Shader.Find("Universal Render Pipeline/Lit"));
    //     }
    // }
}
