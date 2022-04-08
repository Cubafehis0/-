using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public AudioSource audioSource;

    public static MusicManager Instance { get; private set; }

    private void Awake()
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
        if (KeyValue.GetBool("DB_CloseMusic"))
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
    }

}
