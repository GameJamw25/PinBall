using Unity.VisualScripting;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    private bool powerReady;
  private void Start() {
    GameManager.Instance.OnAbilityUpdate += val => powerReady = val;
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKey(KeyCode.E) && powerReady) {
      GameManager.Instance.UseAbility();
    }
    if (Input.GetKey(KeyCode.Q) && GameManager.Instance.balls > 0)
        {
            GameManager.Instance.safeDestroy();
        }
  }
}
