public class TargetPanel : PanelBase
{

    public static TargetPanel instance;

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


}
