using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public static PlaySound instance;

    void Awake()
    {
        instance = this;
    }

    public AudioClip[] clips;

    public void Play(int index, float volume, float pitch)
    {
        AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = clips[index];
        audioSource.volume = volume;
        audioSource.pitch = pitch;

        audioSource.Play();
        Destroy(audioSource, clips[index].length);
    }

    public void Play(int index)
    {
        AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.clip = clips[index];
        audioSource.volume = 0.5f;
        audioSource.pitch = 2;

        audioSource.Play();
        Destroy(audioSource, clips[index].length);
    }

}
