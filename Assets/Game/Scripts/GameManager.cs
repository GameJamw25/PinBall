using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singelton<GameManager> {
  #region
  [Header("Score+ Audio")]
  public AudioClip scoreSound;

  [Header("Game Start Audio")]
  public AudioClip gameStartSound;

  [Header("Game Over Audio")]
  public AudioClip gameOverSound;

  [Header("High Score Audio")]
  public AudioClip highScoreSound;

  // Game stats and Values
  [SerializeField]
  private int score = 0;
  public int abilityCharge = 0;
  private int balls = 0; // Balls in play
  private int lives = 5; // Lives left over
  public CharacterData selectedCharacter; // Selected character and their power
  #endregion

  public Action<int> OnScoreUpdate;
  public Action<int> OnLivesUpdate;
  public Action<float> OnLauncherUpdate;
  public Action<bool> OnAbilityUpdate;
  public Action OnGameOver;
  private void Start() { }

  public void AddScore(int value) {
    score += value;
    OnScoreUpdate?.Invoke(score);
    AudioManager.Instance.playClip(scoreSound);
    AddAbility(value);
  }
  private void AddAbility(int value) {
    if (abilityCharge >= selectedCharacter.powerRequirement) return;
    abilityCharge += value;
    if (abilityCharge >= selectedCharacter.powerRequirement)
      OnAbilityUpdate?.Invoke(true);
  }
  public void UseAbility() {
    if (abilityCharge >= selectedCharacter.powerRequirement) {
      abilityCharge = 0;
      OnAbilityUpdate?.Invoke(false);
      TableManager.Instance.SpawnGumball();
    }
  }

  #region
  // Balls
  public void AddBall() {
    Debug.Log($"Balls in play: {++balls}");
  }
  public void RemoveBall() {
    if (--balls <= 0) {
      if (lives <= 0)
        OnGameOver?.Invoke();
      else {
        SpawnBall();
      }
    }
  }
  private void SpawnBall() {
    OnLivesUpdate?.Invoke(--lives);
    TableManager.Instance?.SpawnBall();
  }
  public void StartFreshGame() {
    lives = 5;
    score = 0;
    AddScore(0);
    abilityCharge = 0;
    SpawnBall();
  }
  #endregion

  public Sprite GetCharImage() { return selectedCharacter.characterSprite; }

  public int GetScore() => score;
}
