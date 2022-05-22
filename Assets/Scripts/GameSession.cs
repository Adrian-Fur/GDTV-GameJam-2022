using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    //Variables
    [SerializeField]
    int playerLives = 1;

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
