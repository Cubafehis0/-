using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MinningMachine : MonoBehaviour
{
    public MiningMachineStatus Status { get; set; } = MiningMachineStatus.Drop;
    // Start is called before the first frame update
    void Start()
    {
        Status = MiningMachineStatus.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
