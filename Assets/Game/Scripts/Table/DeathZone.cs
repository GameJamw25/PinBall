using UnityEngine;

public class DeathZone : MonoBehaviour
{

    [Header("Death Audio")]
    public AudioClip death;
    public static AudioClip deathpublic;

    private void Start()
    {
        deathpublic = death;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            AudioManager.Instance.playClip(death);
            Destroy(other.gameObject);
        }
    }
}
