using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Reflection;
using UnityEngine.Audio;

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
  }
  public override Awaitable MenuOpen() {
    // Set intial values of slider
    masterSlider.minValue = musicSlider.minValue = sfxSlider.minValue = 1e-7f;
    initSlider(sfxSlider, sfxVal, "VolumeSFX");
    initSlider(musicSlider, musicVal, "VolumeMusic");
    initSlider(masterSlider, masterVal, "VolumeMaster");
    return base.MenuOpen();
  }
  public override Awaitable MenuClose() {
    masterSlider.onValueChanged.RemoveAllListeners();
    musicSlider.onValueChanged.RemoveAllListeners();
    sfxSlider.onValueChanged.RemoveAllListeners();
    return base.MenuClose();
  }

  private void initSlider(Slider slider, TextMeshProUGUI volText, string key) {
    // Initial slider setup
    slider.minValue = 1e-7f;
    slider.maxValue = 1f;
    slider.value = AudioManager.Instance.GetVolume(key);
    if (volText) volText.text = Mathf.RoundToInt(slider.value * 100).ToString();

    slider.onValueChanged.AddListener((value) => {
      if (volText) volText.text = Mathf.RoundToInt(value * 100).ToString();
      AudioManager.Instance.SetVolume(key, value);
      PlayerPrefs.SetFloat(key, value);
    });
  }
}
