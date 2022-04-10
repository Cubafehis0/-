public class StoneBookProp:IProp
{
    public void OnGrab(Treasure treasure)
    {
        if (treasure.ID == TreasureID.MinStone || treasure.ID == TreasureID.BigStone)
        {
            PlayerDataMgr.Instance.Score += treasure.Score;
        }
    }
    public void Use(params object[] args)
    {
        MiningMachine.OnDrag.AddListener(OnGrab);
    }
    public void OnRemove(params object[] args)
    {
        MiningMachine.OnDrag.RemoveListener(OnGrab);
    }
}

