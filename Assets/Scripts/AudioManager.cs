using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] playlist;
    public AudioSource audioSource;
    public static AudioManager instance;
    public AudioMixerGroup soundEffectMixer;

    private int musicIndex = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scène");
            return;
        }

        instance = this;
    }

    public void Start()
    {
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }

    public void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    public void PlayNextSong()
    {
        musicIndex = (musicIndex + 1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
    
    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        // Création d'un objet temporaire
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        // Ajoute un AudioSource à tempGo et le retourne
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();

        // Détruit l'objet une fois le son fini
        Destroy(tempGO, clip.length);

        return audioSource;
    }
}
