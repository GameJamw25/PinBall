using UnityEngine;

public class DeathZone : MonoBehaviour{
  void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Ball")) {
      Destroy(other.gameObject);
    }
  }
}
