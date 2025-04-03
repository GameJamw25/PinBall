using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : EchoMenu {
  public TextMeshProUGUI scoreVal;
  public Button mainMenu;
  public async void Start() {
    MenuManager.Instance.HideBackground();
    await MenuManager.Instance.OpenMenu(this);
    GameManager.Instance.StartFreshGame();
    mainMenu.onClick.AddListener(MenuManager.Instance.LoadMainMenu);
    GameManager.Instance.OnGameOver += OnGameOver;
  }

  public async void OnGameOver() {
    animator.Play("NOWGameOver");
    scoreVal.text = "";
    await WaitForAnimation();
  }

  public void TriggerUpdateScore() {
    UpdateScore();
  }
  private async void UpdateScore() {
    Debug.Log("Update Score");
    int i = 0;
    int total = GameManager.Instance.GetScore();
    float time = 0;
    float maxTime = 2;
    while (time < maxTime) {
      time += Time.deltaTime;
      i = (int)Mathf.Lerp(i, total, time / maxTime);
      // i number to comma
      string str = i.ToString("N0");
      scoreVal.text = str;
      await Awaitable.NextFrameAsync();
    }
  }
}
