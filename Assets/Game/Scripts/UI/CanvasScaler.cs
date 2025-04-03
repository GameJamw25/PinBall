using UnityEngine;
using UnityEngine.UI;

public class MyCanvasScaler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CanvasScaler scaler = GetComponent<CanvasScaler>();
        scaler.referencePixelsPerUnit = Screen.height / 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
