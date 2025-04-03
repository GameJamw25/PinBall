using Unity.VisualScripting;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    [Header("PowerUp Audio")]
    public AudioClip powerup;
  private bool powerReady;
  private void Start() {
    GameManager.Instance.OnAbilityUpdate += val => powerReady = val;
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKey(KeyCode.E) && powerReady) {
      GameManager.Instance.UseAbility();
    }
  }
}
