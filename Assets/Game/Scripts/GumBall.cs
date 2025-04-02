using System.Threading.Tasks;
using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class GumBall: Ball {
  //private Rigidbody rb;

  async void Start() {
    await Task.Delay(30000);
    Destroy(gameObject);
    //rb = GetComponent<Rigidbody>();

    //// Ensure the ball is affected by gravity and moves naturally
    ////rb.useGravity = true;
    //rb.mass = 1f; // Default mass
    //rb.linearDamping = 0f; // No air resistance
    //rb.angularDamping = 0f; // No rotation slowing

    //// Ensure constraints are off for natural movement
    //rb.constraints = RigidbodyConstraints.None;
  }

}


