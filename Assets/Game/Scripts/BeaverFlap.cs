using UnityEngine;

public class BeaverFlap : MonoBehaviour {

    [Header("Flap Audio")]
    public AudioClip flap;

    [SerializeField]
  private Rigidbody rb;
  public int score = 10;
  private void OnTriggerEnter(Collider other) {
    if (!other.CompareTag("Ball")) return;
    rb.AddTorque(new Vector3(0, 0, Vector3.Dot(other.GetComponent<Rigidbody>().linearVelocity.normalized, transform.up) > 0 ? 10f : -10f), ForceMode.VelocityChange);
        AudioManager.Instance.playClip(flap);
        GameManager.Instance.AddScore(score);
  }
}
