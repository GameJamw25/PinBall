using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionsMenu : EchoMenu {
  [SerializeField]
  private TextMeshProUGUI masterVal;
  [SerializeField]
  private TextMeshProUGUI musicVal;
  [SerializeField]
  private TextMeshProUGUI sfxVal;
  [SerializeField]
  private Slider masterSlider;
  [SerializeField]
  private Slider musicSlider;
  [SerializeField]
  private Slider sfxSlider;

  private void Start() {
    masterSlider.onValueChanged.AddListener((float value) => { masterVal.text = ((int)(value*100)).ToString(); });
    musicSlider.onValueChanged.AddListener((float value) => { musicVal.text = ((int)(value * 100)).ToString(); });
    sfxSlider.onValueChanged.AddListener((float value) => { sfxVal.text = ((int)(value * 100)).ToString(); });
  }
  public override Awaitable MenuOpen() {
    // Set intial values of slider
    masterSlider.value = .9f;
    musicSlider.value = .69f;
    sfxSlider.value = .30f;
    return base.MenuOpen();
  }
}
