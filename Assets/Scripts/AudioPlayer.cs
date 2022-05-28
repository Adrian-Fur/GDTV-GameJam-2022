using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Coin Pickup")]
    [SerializeField] AudioClip coinPickup;
    [SerializeField] [Range(0f, 1f)] float pickingVolume = 1f;
      
    [Header("Death")]
    [SerializeField] AudioClip deathClip;
    [SerializeField] [Range(0f, 1f)] float deathVolume = 1f;

    [Header("Main Menu Music and Level Music")]
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip levelMusic;

    [SerializeField] private AudioSource source;

    static AudioPlayer instance;

    public void Awake() 
    {   
        ManageAudio();
    }

    void ManageAudio()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    public void Start() 
    {
        PlayMenuMusic();
    }

    public void PlayMenuMusic()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.menuMusic;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }

    public void PlayGameMusic()
    {
        if (instance != null)
        {
            if (instance.source != null)
            {
                instance.source.Stop();
                instance.source.clip = instance.levelMusic;
                instance.source.Play();
            }
        }
        else
        {
            Debug.LogError("Unavailable MusicPlayer component");
        }
    }

    public void PickupCoinClip()
    {
        PlayClip(coinPickup, pickingVolume);
    }

    public void DeathClip()
    {
        PlayClip(deathClip, deathVolume);
    }

    public void GameMusic()
    {
        
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
