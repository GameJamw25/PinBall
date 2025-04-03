using UnityEngine;

public class Goal : MonoBehaviour {

    [Header("Goal Audio")]
    public AudioClip buzzer;

  public int score = 50;
  private void OnTriggerEnter(Collider other) {
    if (!other.CompareTag("Ball")) return;
        AudioManager.Instance.playClip(buzzer);
        GameManager.Instance.AddScore(score);
  }
}
