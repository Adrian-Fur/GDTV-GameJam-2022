using System.Collections;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    LevelManager levelManager;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();

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
        GameOver();
    }

    void GameOver()
    {
        StartCoroutine("LoadGameOverScene");
    }

    public IEnumerator LoadGameOverScene()
    {
        yield return new WaitForSeconds(0.5f);
        levelManager.LoadGameOver();
        Destroy(gameObject);
    }
}
