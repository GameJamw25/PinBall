using UnityEngine;

public class TitleMenu : EchoMenu {
  [SerializeField]
  private EchoMenu optionsMenu;
  [SerializeField]
  private EchoMenu creditsMenu;


  public void OnStartClick() { Debug.Log("Start Game"); }
  public async void OnOptionsClick() { await MenuManager.Instance.OpenMenu(optionsMenu); }
  public async void OnCreditsClick() { await MenuManager.Instance.OpenMenu(creditsMenu); }
  public void OnExitClick() {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.Exit(0);
    #else
        Application.Quit();
    #endif
  }

  // Start is called once before the first execution of Update after the MonoBehaviour is created

  // Update is called once per frame
  void Update() {

  }
}
