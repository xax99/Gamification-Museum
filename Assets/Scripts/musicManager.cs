using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip ambientMusic;
    public AudioClip specialMusic;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        PlayAmbient();
    }

    public void PlayAmbient()
    {
        if (audioSource != null && ambientMusic != null)
        {
            audioSource.clip = ambientMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void PlaySpecial()
    {
        if (audioSource != null && specialMusic != null)
        {
            audioSource.clip = specialMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
