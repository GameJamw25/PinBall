using UnityEngine;

public class DeathZone : MonoBehaviour
{

    [Header("Death Audio")]
    public AudioClip death;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            AudioManager.Instance.playClip(death);
            Destroy(other.gameObject);
        }
    }
}
