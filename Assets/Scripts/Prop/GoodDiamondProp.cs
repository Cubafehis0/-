public class GoodDiamondProp:IProp
{
    public void OnGrab(Treasure treasure)
    {
        if(treasure.ID==TreasureID.Diamond || treasure.ID==TreasureID.DiamondMouse){
            PlayerDataMgr.Instance.Score +=  (int)(treasure.Score * 0.15);
        }
    }
    public void Use(params object[] args)
    {
        MiningMachine.OnDrag2Hand.AddListener(OnGrab);
    }
    public void OnRemove(params object[] args)
    {
        MiningMachine.OnDrag2Hand.RemoveListener(OnGrab);
    }
}