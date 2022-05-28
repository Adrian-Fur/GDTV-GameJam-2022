using UnityEngine;
using TMPro;

public class ScoreCanvas : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    ScoreKeeper scoreKeeper;

    private void Awake() 
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();    
    }

    void Update()
    {
        scoreText.text = scoreKeeper.GetScore().ToString();
    }
}
