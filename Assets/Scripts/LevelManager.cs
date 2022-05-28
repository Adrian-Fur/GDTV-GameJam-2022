using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    ScoreKeeper scoreKeeper;

    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();    
    }

    public void LoadGame()
    {
        if (scoreKeeper != null)
        {
            scoreKeeper.ResetScore();
        }
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
}
