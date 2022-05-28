using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;
    public KeyCode resumeKey;
    public Button resumeButton;

    void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();    
    }

    void Start()
    {
        scoreText.text = "Your Score: \n" + scoreKeeper.GetScore();     
    }

    private void Update() 
    {
        if (Input.GetKeyDown(resumeKey))
        {
            resumeButton.onClick.Invoke();
        }    
    }
}
