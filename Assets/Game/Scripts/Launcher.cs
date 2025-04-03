using System;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{
    [Header("Launcher Audio")]
    public AudioClip release;
    public AudioClip prelaunch;

    [Header("Launcher Settings")]

    public float minLaunchForce = 500f;
    public float maxLaunchForce = 2000f;
    public float chargeSpeed = 1000f;

    [Header("References")]
    public Rigidbody ballRb;
    public Transform launchDirection;

    private float currentLaunchForce;
    private bool isCharging;
  private void Start() {
    GameManager.Instance.OnLauncherUpdate(0f);
  }

  private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isCharging)
        {
            isCharging = true;
            currentLaunchForce = minLaunchForce;
            Debug.Log("Charging");
        }

        if (isCharging && ballRb != null)
        {
          currentLaunchForce += chargeSpeed * Time.deltaTime;
          currentLaunchForce = Mathf.Clamp(currentLaunchForce, minLaunchForce, maxLaunchForce);

          // Animate The UI Power Bar
          GameManager.Instance.OnLauncherUpdate?.Invoke(currentLaunchForce / maxLaunchForce);
        }

        if (Input.GetKeyUp(KeyCode.Space) && isCharging && ballRb != null)
        {
            isCharging = false;
            GameManager.Instance.OnLauncherUpdate?.Invoke(0f);
            LaunchPinball();
        }
    }
    void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Ball")) {
        AudioManager.Instance.playClip(prelaunch);
        ballRb = other.GetComponent<Rigidbody>();
        isCharging = false;
      }
    }
    private void OnTriggerExit(Collider other)
    {
      if (other.CompareTag("Ball")) {
        ballRb = null;
        isCharging = false;
      }
    }

  void LaunchPinball()
  {
    if (ballRb != null && launchDirection != null)
    {
      AudioManager.Instance.playClip(release);
      ballRb.AddForce(launchDirection.right * currentLaunchForce, ForceMode.VelocityChange);
      Debug.Log($"Launch Force: {currentLaunchForce}");
    }
    else
    {
      Debug.LogWarning("PinBall or Launch Direction not assigned");
    }
  }
}
