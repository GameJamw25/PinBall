using UnityEngine;
using UnityEngine.UI;

public class BgScroll : MonoBehaviour {
  private Image _image;
  [SerializeField]
  private float _scrollSpeed = 0.1f;
  private Vector2 originalSize;
  private Material material;

  private void Awake() {
    _image = GetComponent<Image>();
    //_image.SetNativeSize();
    //originalSize = _image.rectTransform.sizeDelta;
    //_image.rectTransform.sizeDelta = new(1920,1080);
  }
  void Start() {
    material = new Material(_image.material);
    _image.material = material;
    material.name = "BgScroll";
    material.mainTextureOffset = new(0, 0);
  }

  private void Update() {
    ScrollBackground();
  }

  private void OnApplicationQuit() {
    _image.material.mainTextureOffset = new(0, 0);
  }

  private void ScrollBackground() {
    Vector2 textureOffset = new(-Time.time * _scrollSpeed, Time.time * _scrollSpeed);
    material.mainTextureOffset = textureOffset;
  }
}
