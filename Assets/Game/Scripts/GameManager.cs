using System;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class GameManager : Singelton<GameManager> {
  #region
  // Game stats and Values
  private int score = 0;
  private int balls = 0; // Balls in play
  private int lives = 5; // Lives left over
  private CharacterData selectedCharacter; // Selected character and their power
  #endregion

  private Action<int> OnScoreUpdate;
  private void Start() {
    SpawnBall();
  }

  public void AddScore(int value) {
    score += value;
    OnScoreUpdate?.Invoke(score);
  }

  #region
  // Balls
  public void AddBall() {
    Debug.Log($"Balls in play: {++balls}");
  }
  public void RemoveBall() {
    if (--balls <= 0) {
      if (lives <= 0)
        Debug.Log("Game Over");
      else {
        SpawnBall();
      }
    }
  }
  private void SpawnBall() {
    lives--;
    TableManager.Instance.SpawnBall();
  }
  #endregion 
}
