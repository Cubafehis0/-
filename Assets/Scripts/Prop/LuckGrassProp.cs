public class LuckGrassProp:IProp
{
    public void Use(params object[] args)
    {
        Chest.p = Chest.p2;
    }
    public void OnRemove(params object[] args)
    {
        Chest.p=Chest.p1;
    }
}