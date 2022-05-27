using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    //Variables
    [SerializeField] int playerLives = 1;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score = 0;

    void Awake()
    {
        int gameSessionsNumber = FindObjectsOfType<GameSession>().Length;
        if (gameSessionsNumber > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = score.ToString();
    }

    public void PlayerDeathProcess()
    {
        GameOver();
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        Mathf.Clamp(score, 0, int.MaxValue);
        scoreText.text = score.ToString();
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
       score = 0;
    }

    void GameOver()
    {
        StartCoroutine("LoadGameOverScene");
    }

    public IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(5);
        Destroy(gameObject);
    }
}
