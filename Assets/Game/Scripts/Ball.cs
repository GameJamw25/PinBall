using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Ball : MonoBehaviour {
  //private Rigidbody rb;

  void Start() {
    //rb = GetComponent<Rigidbody>();

    //// Ensure the ball is affected by gravity and moves naturally
    ////rb.useGravity = true;
    //rb.mass = 1f; // Default mass
    //rb.linearDamping = 0f; // No air resistance
    //rb.angularDamping = 0f; // No rotation slowing

    //// Ensure constraints are off for natural movement
    //rb.constraints = RigidbodyConstraints.None;
  }
  private void OnEnable() {
    GameManager.Instance.AddBall();
  }
  private void OnDisable() {
    GameManager.Instance.RemoveBall();
  }
}


