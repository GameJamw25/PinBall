using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : EchoMenu {
  [SerializeField]
  private EchoMenu optionsMenu;
  [SerializeField]
  private EchoMenu creditsMenu;


  public void OnStartClick() { SceneManager.LoadScene("Assets"); }
  public async void OnOptionsClick() { await MenuManager.Instance.OpenMenu(optionsMenu); }
  public async void OnCreditsClick() { await MenuManager.Instance.OpenMenu(creditsMenu); }
  public void OnExitClick() {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.Exit(0);
    #else
        Application.Quit();
    #endif
  }
}
