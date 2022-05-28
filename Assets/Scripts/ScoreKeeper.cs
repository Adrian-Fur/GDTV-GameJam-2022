using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;

    static ScoreKeeper instance;

    void Awake() 
    {
        ManageScore();
    }

    void ManageScore()
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

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        Mathf.Clamp(score, 0, int.MaxValue);
        CheckHighScore();
    }

    void CheckHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

    public void ResetScore()
    {
        score = 0;
    }
}
