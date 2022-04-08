using UnityEngine;

public class PlayerMiner : MonoBehaviour
{
    [SerializeField] MiningMachine miningMachine;
    [SerializeField] Animator animator;
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(IsDropAble)
            {
                miningMachine.Status = MiningMachineStatus.Drop;
            }
        }

        animator.SetInteger("State", (int)miningMachine.Status);
        animator.SetFloat("Speed", miningMachine.Speed);
        Debug.Log(miningMachine.Speed);
        miningMachine.UpdateProcess();
    }
    


    private bool IsDropAble=>miningMachine.Status == MiningMachineStatus.Idle;


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.tag == "Hook")
        {
            if (miningMachine.Status != MiningMachineStatus.Idle)
            {
                miningMachine.Status = MiningMachineStatus.Idle;
            }
        }
        else if (collision.tag == "Treasures")
        {
            Treasure treasure = collision.GetComponentInParent<Treasure>();
            if (treasure == miningMachine.DragTreasure)
            {
                PlayerDataMgr.Instance.Score+=treasure.Score;
                miningMachine.DragTreasure = null;
                GameObject.Destroy(treasure.gameObject);
            }
        }
    }

}
