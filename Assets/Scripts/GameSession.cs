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
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            GameOver();
        }
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        Mathf.Clamp(score, 0, int.MaxValue);
        scoreText.text = score.ToString();
    }

    void TakeLife()
    {
        playerLives --;
        StartCoroutine("ResetScene");
    }

    public IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(0.5f);
        int currnetSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(currnetSceneIndex);
    }

    void GameOver()
    {
        StartCoroutine("LoadGameOverScene");
    }

    public IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
