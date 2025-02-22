using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayRemoteSound : MonoBehaviour
{
    public AudioClip sound = null;
  
    public float volume = 1.0f;

    [Range(0, 1)] public float randomPitchVariance = 0.0f;

    private AudioSource audioSource = null;

    private float defaultPitch = 1.0f;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        float randomVariance = Random.Range(-randomPitchVariance, randomPitchVariance);
        randomVariance += defaultPitch;

        audioSource.pitch = randomVariance;
        audioSource.PlayOneShot(sound, volume);
        audioSource.pitch = defaultPitch;
    }

    private void OnValidate()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }
}
