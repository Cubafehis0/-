using UnityEngine;

public class PlayerMiner : MonoBehaviour
{
#pragma warning disable CS0649 // 从未对字段“PlayerMiner.miningMachine”赋值，字段将一直保持其默认值 null
    [SerializeField] MiningMachine miningMachine;
#pragma warning restore CS0649 // 从未对字段“PlayerMiner.miningMachine”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“PlayerMiner.animator”赋值，字段将一直保持其默认值 null
    [SerializeField] Animator animator;
#pragma warning restore CS0649 // 从未对字段“PlayerMiner.animator”赋值，字段将一直保持其默认值 null

    public void Drop()
    {
        if (IsDropAble())
        {
            animator.Play("Drab");
            miningMachine.Status = MiningMachineStatus.Drop;

            var levelEntity = EntityManager.Instance.GetLevelEntity();
            if (!levelEntity.isTimeOrStep)
                BattleCanvas.Instance.GetScoreTipPanel().SetTimeOrStep(--levelEntity.timeStep);
        }
    }


    public bool IsDropAble()
    {
        return miningMachine.Status == MiningMachineStatus.Idle;
    }


    public void UpdateProcess()
    {
        miningMachine.UpdateProcess();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hook")
        {
            if (miningMachine.Status != MiningMachineStatus.Idle)
            {
                animator.Play("Idle");
                miningMachine.Status = MiningMachineStatus.Idle;
            }
        }
        else if (collision.tag == "Treasures")
        {
            Treasure treasure = collision.GetComponentInParent<Treasure>();
            if (treasure == miningMachine.DragTreasure)
            {
                BattleCanvas.Instance.AddScore(treasure.GetScore());
                miningMachine.DragTreasure = null;
                GameObject.Destroy(treasure.gameObject);
            }
        }
    }

}
