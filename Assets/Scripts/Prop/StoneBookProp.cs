using System.Diagnostics;
using UnityEngine;

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
        MiningMachine.OnDrag2Hand.AddListener(OnGrab);
    }
    public void OnRemove(params object[] args)
    {
        MiningMachine.OnDrag2Hand.RemoveListener(OnGrab);
    }
    
    public void OnGrabTest1()
    {
        Treasure treasure=TreasurePool.GetTreasure(TreasureID.MinStone).GetComponent<Treasure>();
        int score1=PlayerDataMgr.Instance.Score; 
        OnGrab(treasure);
        int score2=PlayerDataMgr.Instance.Score;
        System.Diagnostics.Debug.Assert(score2 == score1 + treasure.Score);
        GameObject.DestroyImmediate(treasure.gameObject);
    }
    public void OnGrabTest2()
    {
        Treasure treasure = TreasurePool.GetTreasure(TreasureID.Mouse).GetComponent<Treasure>();
        int score1 = PlayerDataMgr.Instance.Score;
        OnGrab(treasure);
        int score2 = PlayerDataMgr.Instance.Score;
        System.Diagnostics.Debug.Assert(score2 == score1);
        GameObject.DestroyImmediate(treasure.gameObject);
    }
}
