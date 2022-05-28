using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    AudioPlayer audioPlayer;

    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();    
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public void LoadGame()
    {
        if (scoreKeeper != null)
        {
            scoreKeeper.ResetScore();
        }
        audioPlayer.GameMusic();
        SceneManager.LoadScene("MainGame");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }
}
