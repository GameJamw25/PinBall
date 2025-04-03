using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class GumBall: Ball {
  //private Rigidbody rb;
public int ms=15000;
  protected override async void Start() {
        base.Start();
    await Task.Delay(ms);
    Debug.Log("Destroying Gumball");
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


