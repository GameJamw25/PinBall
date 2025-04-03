using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class InGameUI : MonoBehaviour {
  [SerializeField]
  private TextMeshProUGUI scoreVal;
  [SerializeField]
  private TextMeshProUGUI bitesVal;
  [SerializeField]
  private Slider slider;
  [SerializeField]
  private Image abilityImage;
  [SerializeField]
  private Image charImage;
  void OnEnable() {
    GameManager.Instance.OnScoreUpdate += UpdateScore;
    GameManager.Instance.OnLivesUpdate += UpdateBites;
    GameManager.Instance.OnLauncherUpdate += UpdateSlider;
    GameManager.Instance.OnAbilityUpdate += UpdateAbilityImage;
    charImage.sprite = GameManager.Instance.GetCharImage();
    abilityImage.color = Color.clear;
  }
  void OnDisable() {
    if (GameManager.Instance == null) return; // Avoids null reference if game is over
    GameManager.Instance.OnScoreUpdate -= UpdateScore;
    GameManager.Instance.OnLivesUpdate -= UpdateBites;
    GameManager.Instance.OnLauncherUpdate -= UpdateSlider;
  }

  public void UpdateScore(int val) {
    scoreVal.text = val.ToString();
  }
  public void UpdateBites(int val) {
    bitesVal.text = val.ToString();
  }
  public void UpdateSlider(float val) {
    slider.value = val;
  }
  public void UpdateAbilityImage(bool val) {
    if (val) {
      abilityImage.color = Color.white;
    } else {
      abilityImage.color = Color.clear;
    }
  }
}
