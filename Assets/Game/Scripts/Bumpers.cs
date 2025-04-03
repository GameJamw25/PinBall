using UnityEngine;

public class Bumpers : MonoBehaviour
{
    [Header("Bumper Audio")]
    public AudioClip bump;

    [SerializeField, Range(10f,100f)] private float impulseForce = 30f; // Force applied to the ball
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Ensure ball has the "Ball" tag
        {
            Rigidbody ballRb = collision.rigidbody;
            if (ballRb != null)
            {
                Vector3 impactDirection = (collision.transform.position - transform.position).normalized;
                ballRb.AddForce(impactDirection * impulseForce, ForceMode.Impulse);
                AudioManager.Instance.playClip(bump);
                GameManager.Instance.AddScore(10);
            }
        }
    }
}
