using UnityEngine;
public class BombProp : IProp
{
    public void OnRemove(params object[] args)
    {
        
    }
    public void Use(params object[] args)
    {
        SoundManager.Instance.PlayMusic("Explosion");
        if (args.Length == 0) return;
        MiningMachine miner=args[0] as MiningMachine;
        if(miner != null)
        {
            GameObject.Destroy(miner.DragTreasure.gameObject);
            miner.DragTreasure = null;
        }
    }
}
