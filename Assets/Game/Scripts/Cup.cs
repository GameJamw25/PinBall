using UnityEngine;

public class Cup : MonoBehaviour {

    [Header("Cup Audio")]
    public AudioClip woosh;
  private async void OnTriggerEnter(Collider other) {
    if (!other.CompareTag("Ball")) return;
        AudioManager.Instance.playClip(woosh);
        await Awaitable.WaitForSecondsAsync(1);
        other.attachedRigidbody.AddForce(transform.forward * 100, ForceMode.VelocityChange);
    }
}
