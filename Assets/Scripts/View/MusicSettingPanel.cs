using UnityEngine.UI;
using UIFramework;
using Singleton;
public class MusicSettingPanel : BaseView
{

    public static MusicSettingPanel instance;
    public Image MusicON;
    public Image MusicOFF;
    public Image SoundON;
    public Image SoundOFF;
    public override void OnEnter(BaseContext context)
    {
        base.OnEnter(context);
        ResMusicPanel();
    }
    private void ResMusicPanel()
    {
        bool DB_CloseMusic = KeyValue.GetBool("DB_CloseMusic");
        bool DB_CloseSound = KeyValue.GetBool("DB_CloseSound");
        if (DB_CloseMusic)
        {
            MusicON.gameObject.SetActive(false);
            MusicOFF.gameObject.SetActive(true);
        }
        else
        {
            MusicON.gameObject.SetActive(true);
            MusicOFF.gameObject.SetActive(false);
        }
        if (DB_CloseSound)
        {
            SoundON.gameObject.SetActive(false);
            SoundOFF.gameObject.SetActive(true);
        }
        else
        {
            SoundON.gameObject.SetActive(true);
            SoundOFF.gameObject.SetActive(false);
        }
        MusicManager.Instance.RefreshSound();
        SoundManager.Instance.RefreshSound();
    }
    public void ClickMusic()
    {
        bool DB_CloseMusic = KeyValue.GetBool("DB_CloseMusic");
        KeyValue.SetBool("DB_CloseMusic", !DB_CloseMusic);
        ResMusicPanel();
        SoundManager.Instance.PlayMusic("BtnClick");
    }
    public void ClickSound()
    {
        bool DB_CloseSound = KeyValue.GetBool("DB_CloseSound");
        KeyValue.SetBool("DB_CloseSound", !DB_CloseSound);
        ResMusicPanel();
        SoundManager.Instance.PlayMusic("BtnClick");
    }
    public void Click2Exit()
    {
        SoundManager.Instance.PlayMusic("BtnClick");
        Singleton<ContextManager>.Instance.Pop();
    }
}
