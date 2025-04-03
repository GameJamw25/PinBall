using UnityEngine;
public class MenuManager : Singelton<MenuManager> {
  [SerializeField]
  private EchoMenu currentMenu;
  [SerializeField]
  private EchoMenu startMenu;
  public async Awaitable OpenMenu(EchoMenu newMenu) {
    if (currentMenu != null) {
      await currentMenu.MenuClose();
    }
    currentMenu = newMenu;
    await currentMenu.MenuOpen();
  }

  public void Start() {
    OpenMenu(startMenu);
  }
}
