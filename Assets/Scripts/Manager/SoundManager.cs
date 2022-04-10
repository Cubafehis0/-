using System;
using UnityEngine;
[System.Serializable]
public class StringAudioClipDictionary : SerializableDictionary<string, AudioClip> { }
public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public static SoundManager Instance;
    [SerializeField]
    private StringAudioClipDictionary audioClips;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
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
