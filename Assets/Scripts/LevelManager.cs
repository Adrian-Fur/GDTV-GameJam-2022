using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Texture2D cursorArrow;

    ScoreKeeper scoreKeeper;
    AudioPlayer audioPlayer;

    void Awake() 
    {
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        scoreKeeper = FindObjectOfType<ScoreKeeper>();    
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    public void LoadGame()
    {
        if (scoreKeeper != null)
        {
            scoreKeeper.ResetScore();
        }
        Cursor.visible = false;
        audioPlayer.PlayGameMusic();
        SceneManager.LoadScene("MainGame");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver()
    {
        Cursor.visible = true;
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

    public void LoadControls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void LoadTips()
    {
        SceneManager.LoadScene("Tips");
    }

    public void PauseToMenu()
    {
        audioPlayer.PlayMenuMusic();
        SceneManager.LoadScene("MainMenu");
    }
}
