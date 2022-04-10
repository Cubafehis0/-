using UnityEngine;

public class PlayerMiner : MonoBehaviour
{
    [SerializeField] MiningMachine miningMachine;
    [SerializeField] Animator animator;
    public void Update()
    {
        if (GameControl.Instance.isGaming)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (IsDropAble)
                {
                    SoundManager.Instance.PlayMusic("Drop");
                    miningMachine.Status = MiningMachineStatus.Drop;
                }
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (miningMachine.Status == MiningMachineStatus.Drag)
                {
                    if (PlayerDataMgr.Instance.ContainProp(PropID.Bomb))
                    {
                        PlayerDataMgr.Instance.UseProp(PropID.Bomb, miningMachine);
                    }
                }
            }
            animator.SetInteger("State", (int)miningMachine.Status);
            animator.SetFloat("Speed", miningMachine.Speed);
            miningMachine.UpdateProcess();
        }        
    }
    private bool IsDropAble=>miningMachine.Status == MiningMachineStatus.Idle;
}
