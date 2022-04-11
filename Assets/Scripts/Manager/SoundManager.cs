using System;
using UnityEngine;
[System.Serializable]
public class StringAudioClipDictionary : SerializableDictionary<string, AudioClip> { }
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    AudioSource audioSource;
    public static SoundManager Instance;
    [SerializeField]
    private StringAudioClipDictionary audioClips=new StringAudioClipDictionary();
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        audioSource = GetComponent<AudioSource>();
        Instance = this;
        DontDestroyOnLoad(gameObject);
        RefreshSound();
    }
    public void RefreshSound()
    {
        if (KeyValue.GetBool("DB_CloseSound"))
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
            audioSource.PlayOneShot(audioClips[name]);
        else Debug.Log($"{name}音效不存在");
    }
}
