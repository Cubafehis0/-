public class LosePanel : PanelBase
{

    public static LosePanel instance;

    public override void Init(params object[] args)
    {
        base.Init(args);
        layer = PanelLayer.Panel;
        instance = this;

    }

    public override void OnShowing()
    {
        base.OnShowing();

    }

    public void OnLVButton()
    {
        //SoundManager.instance.PlayBtn();
        //SceneJump.instance.Jump(SceneType.Map);
    }

    public void OnReplayButton()
    {
        //SoundManager.instance.PlayBtn();
        //SceneJump.instance.Jump(SceneType.Game);
    }
}
