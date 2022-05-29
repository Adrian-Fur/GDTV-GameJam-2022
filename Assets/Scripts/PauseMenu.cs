using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public KeyCode resumeKey;
    public Button resumeButton;
    
    LevelManager levelManager;

    private void Awake() 
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

         if (Input.GetKeyDown(resumeKey) && GameIsPaused)
            {
                resumeButton.onClick.Invoke();
            } 
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        levelManager.PauseToMenu();
    }
}
