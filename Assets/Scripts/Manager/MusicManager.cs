﻿using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{

    AudioSource audioSource;

    public static MusicManager Instance { get; private set; }
    [SerializeField]
    private StringAudioClipDictionary audioClips;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();  
        RefreshSound();
    }
    public void RefreshSound()
    {
        if (KeyValue.GetBool("DB_CloseMusic"))
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
    }
    public void PlayMusic(string name)
    {
        if (audioClips.ContainsKey(name))
        {
            audioSource.clip= audioClips[name];
            audioSource.Play();
        }
        else Debug.Log($"{name}音效不存在");

    }
}
