using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Ball : MonoBehaviour {
    virtual protected void Start() {
    Renderer rb = GetComponent<Renderer>();
    int i = Random.Range(1, 5);
    rb.material = Resources.Load<Material>("Timbits/Timbit" + i);
  }
  private void OnEnable() {
    GameManager.Instance.AddBall();
  }
  private void OnDisable() {
    GameManager.Instance?.RemoveBall();
  }
}


