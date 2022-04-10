public class PropManager
{
    public static string GetPropInfo(PropID id)
    {
        return id switch
        {
            PropID.LuckGress => "在下一回合里，玩家钩取宝箱会获得更好的奖励",
            PropID.GoodDiamond => "在下一回合里，玩家钩取的钻石可以获得更高的奖励",
            PropID.StoneBook => "在下一回合里，玩家钩取的石头可以获得更高的奖励",
            PropID.Bomb => "当你抓到较重而且钱不多的物品时，按下上方向键使用炸药将其销毁",
            PropID.StrengthWater => "在下一回合里，加快玩家的出钩速度和回钩速度",
            _ => ""
        };
    }
    public static PropRemoveType GetPropRemoveType(PropID id)
    {
        return id switch
        {
            PropID.Bomb => PropRemoveType.AfterUse,
            _ => PropRemoveType.OnTurnEnd
        };
    }
    public static PropUseType GetPropUseType(PropID id)
    {
        return id switch
        {
            PropID.Bomb => PropUseType.Hand,
            _ => PropUseType.Auto
        };
    }
    public static IProp CreateProp(PropID id)
    {
        return id switch
        {
            PropID.Bomb => new BombProp(),
            PropID.LuckGress => new LuckGressProp(),
            PropID.StrengthWater => new StrengthWaterProp(),
            PropID.GoodDiamond => new GoodDiamondProp(),
            PropID.StoneBook => new StoneBookProp(),
            _=>null
        };
    }
}
