using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : EchoMenu
{
    [SerializeField]
    private EchoMenu optionsMenu;
    [SerializeField]
    private EchoMenu creditsMenu;

    public AudioClip selection;


    public void OnStartClick()
    {
        SceneManager.LoadScene("Assets");
        AudioManager.Instance.gameEnterSound();
    }
    public async void OnOptionsClick() {
        AudioManager.Instance.menuSelectSound();
        await MenuManager.Instance.OpenMenu(optionsMenu);
    }
    public async void OnCreditsClick() {
        AudioManager.Instance.menuSelectSound();
        await MenuManager.Instance.OpenMenu(creditsMenu);
    }
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.Exit(0);
#else
        Application.Quit();
#endif
    }
}
