using Singleton;
using UIFramework;
public class LosePanel : BaseView
{
    public override void OnEnter(BaseContext context)
    {
        base.OnEnter(context);

        MusicManager.Instance.PlayMusic("Lose");
    }
    public void RestartGame()
    {
        SoundManager.Instance.PlayMusic("BtnClick");
        SceneJump.Instance.Jump(SceneType.Start);
    }   
}
