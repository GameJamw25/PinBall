using System;
using UnityEngine;

public class Flappers : MonoBehaviour
{
    public HingeJoint joint;
    public KeyCode inputKey = KeyCode.LeftArrow;

    [SerializeField] private float motorForce = 2500f;

    [SerializeField] private float motorSpeed = 250f;

    [SerializeField] private float impulseForce = 10f; // Force applied to the ball

    private void Start()
    {
        joint = GetComponent<HingeJoint>();
        
    }

    private void Update()
    {
        JointMotor motor = joint.motor;

        if (Input.GetKeyDown(inputKey))
        {
            motor.targetVelocity = motorSpeed;
            Debug.Log("Flap");
        }
        else if (Input.GetKeyUp(inputKey))
        {
            motor.targetVelocity = -motorSpeed;
        }

        motor.force = motorForce;
        motor.freeSpin = false;
        joint.motor = motor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Ensure ball has the "Ball" tag
        {
            Rigidbody ballRb = collision.rigidbody;
            if (ballRb != null)
            {
                Vector3 impactDirection = (collision.transform.position - transform.position).normalized;
                ballRb.AddForce(impactDirection * impulseForce, ForceMode.Impulse);
            }
        }
    }
}
