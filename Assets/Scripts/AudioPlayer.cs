using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Coin Pickup")]
    [SerializeField] AudioClip coinPickup;
    [SerializeField] [Range(0f, 1f)] float pickingVolume = 1f;
      
    [Header("Death")]
    [SerializeField] AudioClip deathClip;
    [SerializeField] [Range(0f, 1f)] float deathVolume = 1f;

    AudioSource audioSource;

    public AudioClip newTrack;

    static AudioPlayer instance;

    void Awake() 
    {   
        audioSource = GetComponet<AudioSource>();
        ManageAudio();
    }

    void ManageAudio()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
