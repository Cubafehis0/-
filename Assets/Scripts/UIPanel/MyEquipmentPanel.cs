public class MyEquipmentPanel : PanelBase
{

    public static MyEquipmentPanel instance;

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
