using UnityEngine;

public class SpeedyBalls : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 10f; // Torque force
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > 0.1f) // If the ball is moving
        {
            Vector3 rollDirection = Vector3.Cross(Vector3.up, rb.linearVelocity.normalized); // Perpendicular to movement
            rb.AddTorque(rollDirection * rollSpeed, ForceMode.Acceleration);
        }
    }
}
