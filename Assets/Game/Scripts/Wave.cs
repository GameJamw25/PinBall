using UnityEngine;

public class Wave : MonoBehaviour {

    [Header("Geese Audio")]
    public AudioClip geese;
  private void OnTriggerEnter(Collider other) {
    if (!other.CompareTag("Ball")) return;
        AudioManager.Instance.playClip(geese);
  }
}
