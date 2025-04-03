using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;

public class AudioManager : Singelton<AudioManager>
{
    public AudioMixer AudioMixer;
    public AudioMixerGroup sfxMix;
    public AudioMixerGroup musicMix;
    public AudioSource musicPlayer;
    public List<AudioSource> soundPlayers;
    public AudioClip menuSelection;
    public AudioClip gameEnter;

    private AudioLooper activeLoop;

    public void SetVolume(string key, float volume)
    {
        PlayerPrefs.SetFloat(key, volume);
        AudioMixer.SetFloat(key, Mathf.Log10(volume) * 20);
    }
    public float GetVolume(string key) {
        AudioMixer.GetFloat(key, out float value);
        return Mathf.Pow(10, value / 20);
    }
  public async Awaitable playClip(AudioClip clip)
    {
        AudioSource current = null;
        foreach (AudioSource player in soundPlayers)
        {
            if (!player.isPlaying)
            {
                current = player;
                break;
            }
        }
        if (current == null)
        {
            current = gameObject.AddComponent<AudioSource>();
            current.outputAudioMixerGroup = sfxMix;
            soundPlayers.Add(current);
        }
        current.clip = clip;
        current.Play();
        while(current.isPlaying)
        {
            await Awaitable.NextFrameAsync();
        }
    }
    public async Awaitable playSFX(AudioSFX SFX)
    {
        await
        playClip(SFX.SFXclips[Random.Range(0, SFX.SFXclips.Length)]);
    }

    public void Start() {
        if (!musicPlayer) {
            musicPlayer = gameObject.AddComponent<AudioSource>();
            musicPlayer.outputAudioMixerGroup = musicMix;
        }
        string[] keys = {
            "VolumeMaster",
            "VolumeMusic",
            "VolumeSFX"
        };
        foreach (string key in keys) {
            AudioMixer.SetFloat(key, Mathf.Log10(PlayerPrefs.GetFloat(key, 1)) * 20);
        }
    }

    public void menuSelectSound()
    {
        playClip(menuSelection);
    }

    public void gameEnterSound()
    {
        playClip(gameEnter);
    }

    public static T CopyComponent<T>(T original, GameObject destination) where T : Component
    {
        var type = original.GetType();
        var copy = destination.AddComponent(type);
        var fields = type.GetFields();
        foreach (var field in fields) field.SetValue(copy, field.GetValue(original));
        return copy as T;
    }

    public void PlayMusic(AudioClip intro, AudioClip main) {
        if (activeLoop != null) musicPlayer.Stop();
        activeLoop = new AudioLooper(intro, main);
        activeLoop.initPlayer(musicPlayer);
    }
}
