using UnityEngine;
using UnityEngine.UI;
using UIFramework;
using Singleton;
public class WinPanelContext : BaseContext
{
    public int Score;
    public WinPanelContext(UIType viewType) : base(viewType)
    {
        Score = PlayerDataMgr.Instance.Score;
    }
}
public class WinPanel : BaseView
{
    [SerializeField] Text scoreText;
    public override void OnEnter(BaseContext context)
    {
        MusicManager.Instance.PlayMusic("Win");
        base.OnEnter(context);
        scoreText.text=(context as WinPanelContext).Score.ToString();
    }
    public void Click2Restart()
    {
        SoundManager.Instance.PlayMusic("BtnClick");
        SceneJump.Instance.Jump(SceneType.Start);
    }
}
