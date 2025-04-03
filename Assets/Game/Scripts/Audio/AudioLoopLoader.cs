using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoopLoader : MonoBehaviour {
    public AudioClip intro;
    public AudioClip main;
    void Start() {
        AudioManager.Instance.PlayMusic(intro, main);
        Destroy(gameObject);
    }
}
