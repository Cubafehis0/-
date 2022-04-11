using UnityEngine;

public class PlayerMiner : MonoBehaviour
{
    [SerializeField] MiningMachine miningMachine;
    [SerializeField] Animator animator;
    public void Update()
    {
        if (GameControl.Instance.IsGaming!=miningMachine.enabled)
        {
            miningMachine.enabled = GameControl.Instance.IsGaming;
        }
        animator.SetInteger("State", (int)miningMachine.Status);
        animator.SetFloat("Speed", miningMachine.Speed);
    }
}
