public class ResurgencePanel : PanelBase
{

    public static ResurgencePanel instance;

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
