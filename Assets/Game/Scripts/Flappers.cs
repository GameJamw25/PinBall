using System;
using UnityEngine;

public class Flappers : MonoBehaviour
{
  public Rigidbody rb;
  public KeyCode inputKey = KeyCode.LeftShift;
  public Vector3 rest;
  public Vector3 target;

  [SerializeField] private float impulseForce = 10f; // Force applied to the ball

  private void Start() {
    rb = GetComponent<Rigidbody>();
    rb.interpolation = RigidbodyInterpolation.Interpolate;
    rb.MoveRotation(Quaternion.Euler(rest));
  }

  private void Update(){
    if (Input.GetKeyDown(inputKey))
      rb.MoveRotation(Quaternion.Euler(target));
    else if (Input.GetKeyUp(inputKey))
      rb.MoveRotation(Quaternion.Euler(rest));
  }

  //private void OnCollisionEnter(Collision collision) {
  //  if (collision.gameObject.CompareTag("Ball")) {
  //    Rigidbody ballRb = collision.rigidbody;
  //    if (ballRb != null) {
  //      Vector3 impactDirection = (collision.transform.position - transform.position).normalized;
  //      ballRb.AddForce(impactDirection * impulseForce, ForceMode.Impulse);
  //    }
  //  }
  //}
}
