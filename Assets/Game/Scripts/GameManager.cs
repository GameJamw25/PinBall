using System;
using UnityEngine;

public class GameManager : Singelton<GameManager> {
  #region
  [Header("Score+ Audio")]
  public AudioClip scoreSound;

  // Game stats and Values
  private int score = 0;
  public int abilityCharge = 0;
  private int balls = 0; // Balls in play
  private int lives = 5; // Lives left over
  public CharacterData selectedCharacter; // Selected character and their power
  #endregion

    private Action<int> OnScoreUpdate;
    private void Start()
    {
        SpawnBall();
    }

    public void AddScore(int value)
    {
        score += value;
        OnScoreUpdate?.Invoke(score);
        AudioManager.Instance.playClip(scoreSound);
        if (abilityCharge < 1000)
        {
            abilityCharge += value;
            if (abilityCharge > 1000) {abilityCharge = 1000;}
            OnScoreUpdate?.Invoke(abilityCharge);
        }
    }

    #region
    // Balls
    public void AddBall()
    {
        Debug.Log($"Balls in play: {++balls}");
    }
    public void RemoveBall()
    {
        if (--balls <= 0)
        {
            if (lives <= 0)
                Debug.Log("Game Over");
            else
            {
                SpawnBall();
            }
        }
    }
    private void SpawnBall()
    {
        lives--;
        TableManager.Instance.SpawnBall();
    }
    #endregion
}
