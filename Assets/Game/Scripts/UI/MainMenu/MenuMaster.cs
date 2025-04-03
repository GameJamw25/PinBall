using UnityEngine;
using UnityEngine.UI;
public class MenuManager : Singelton<MenuManager> {
  [SerializeField]
  private EchoMenu currentMenu;
  [SerializeField]
  private EchoMenu startMenu;
  [SerializeField]
  private Image[] colors;

  public async Awaitable OpenMenu(EchoMenu newMenu) {
    newMenu.MenuOpenPrep();
    if (currentMenu != null) {
      await currentMenu.MenuClose();
    }
    currentMenu = newMenu;
    await currentMenu.MenuOpen();
  }

  public void Start() {
    OpenMenu(startMenu);
  }

  public async void HideBackground() {
    float fadeTime = 0.5f;
    float totalTime = 0;

    // interpolate the alpha value of the colors from 1 to 0 over fadeTime
    while (totalTime < fadeTime) {
      totalTime += Time.deltaTime;

      float alpha = Mathf.Lerp(1, 0, totalTime / fadeTime);
      foreach (Image image in colors) {
        image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
      }
      await Awaitable.NextFrameAsync();
    }
    
  }
}
