using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField]
    int pointsForCoin = 10;
    bool wasCollected = false;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" && !wasCollected)
        {
            wasCollected = true;
            audioPlayer.PickupCoinClip();
            FindObjectOfType<GameSession>().AddToScore(pointsForCoin);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }    
    }
}
