using UnityEngine;

public class Bumpers : MonoBehaviour
{
    [Header("Bumper Audio")]
    public AudioClip bump;

    [SerializeField, Range(1f,100f)] private float impulseForce = 30f; // Force applied to the ball
  public int score = 10;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Ensure ball has the "Ball" tag
        {
            Rigidbody ballRb = collision.rigidbody;
            if (ballRb != null)
            {
                Vector3 impactDirection = (collision.transform.position - transform.position).normalized;
                Vector3 projectedVector = impactDirection - Vector3.Dot(impactDirection, -transform.forward) * -transform.forward;
                projectedVector.Normalize();

        
                ballRb.AddForce(projectedVector * impulseForce, ForceMode.VelocityChange);
                AudioManager.Instance.playClip(bump);
                GameManager.Instance.AddScore(score);
            }
        }
    }
}
