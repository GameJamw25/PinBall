using TMPro;
using UnityEngine;

public class ScoreManager : Singelton<ScoreManager>
{

    private int score = 0;
    
    public TextMeshProUGUI scoreText;
    
    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
        
    }

    private void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score:" + score.ToString();
        }
    }
}
