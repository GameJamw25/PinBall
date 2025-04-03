using UnityEngine;

public class GameOverMenu : EchoMenu {
  public async void Start() {
    MenuManager.Instance.HideBackground();
    await MenuManager.Instance.OpenMenu(this);
    GameManager.Instance.StartFreshGame();
  }
}
