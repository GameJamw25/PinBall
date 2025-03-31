using System;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{ 
    [Header("Launcher Settings")]
    
    public float minLaunchForce = 500f;
    public float maxLaunchForce = 2000f;
    public float chargeSpeed = 1000f;
    
    [Header("References")]
    
    public Rigidbody ballRb;
    public Transform launchDirection;
    public Image powerBar;
    
    private float currentLaunchForce;
    private bool isCharging;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCharging = true;
            currentLaunchForce = minLaunchForce;
            Debug.Log("Charging");
        }

        if (isCharging)
        {
            currentLaunchForce += chargeSpeed * Time.deltaTime;
            currentLaunchForce = Mathf.Clamp(currentLaunchForce, minLaunchForce, maxLaunchForce);

            if (powerBar != null)
            {
              float fillValue = (currentLaunchForce - minLaunchForce) / (maxLaunchForce - minLaunchForce);
                powerBar.fillAmount = fillValue;
            }
            
        }
        
        if (Input.GetKeyUp(KeyCode.Space) && isCharging)
        {
            isCharging= false;
            if(powerBar!=null)
            {
                powerBar.fillAmount = 0f;
            }
            LaunchPinball();
        }
        
    }

    void LaunchPinball()
    {
        if(ballRb != null && launchDirection != null)
        {
            ballRb.AddForce(-launchDirection.right * currentLaunchForce);
        }else
        {
            Debug.LogWarning("PinBall or Launch Direction not assigned");
        }
    }
}
