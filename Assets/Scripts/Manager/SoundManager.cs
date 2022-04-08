using System;
using UnityEngine;
[System.Serializable]
public class StringAudioClipDictionary : SerializableDictionary<string, AudioClip> { }
public class SoundManager : MonoBehaviour
{

    public AudioSource audioSource;

    public static SoundManager instance;
    [SerializeField]
    private StringAudioClipDictionary audioClips;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        RefreshSound();
    }

    // Use this for initialization
    void Start()
    {

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
        if(audioClips.ContainsKey(name))
            audioSource.PlayOneShot(audioClips[name]);
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void PlayBtn()
    {
        throw new NotImplementedException();
    }
}
