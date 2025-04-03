using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    foreach (Image image in colors) image.gameObject.SetActive(false);
  }

  // Show background
  public async Awaitable ShowBackground() {
    float fadeTime = 0.5f;
    float totalTime = 0;

    // set the alpha value of the colors to 0
    foreach (Image image in colors) {
      image.gameObject.SetActive(true);
    }

    // interpolate the alpha value of the colors from 0 to 1 over fadeTime
    while (totalTime < fadeTime) {
      totalTime += Time.deltaTime;

      colors[0].color = new Color(colors[0].color.r, colors[0].color.g, colors[0].color.b, Mathf.Lerp(0, 1, totalTime / fadeTime));
      colors[1].color = new Color(colors[1].color.r, colors[1].color.g, colors[1].color.b, Mathf.Lerp(0, 0.3137254902f, totalTime / fadeTime));
      
      await Awaitable.NextFrameAsync();
    }
  }

  public async void LoadMainMenu() {
    await SceneManager.LoadSceneAsync("MainMenu");
    await ShowBackground();
    GameObject temp = currentMenu.gameObject;
    await OpenMenu(startMenu);
    Destroy(temp);
  }
}
