using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Coin Pickup")]
    [SerializeField] AudioClip coinPickup;
    [SerializeField] [Range(0f, 1f)] float pickingVolume = 1f;
      
    [Header("Death")]
    [SerializeField] AudioClip deathClip;
    [SerializeField] [Range(0f, 1f)] float deathVolume = 1f;

    public void PickupCoinClip()
    {
        PlayClip(coinPickup, pickingVolume);
    }

    public void DeathClip()
    {
        PlayClip(deathClip, deathVolume);
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
