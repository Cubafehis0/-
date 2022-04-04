using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MininMachineIdleTest
{
    private static MinningMachine ArrangeMinningMachine()
    {
        GameObject gameObject = new GameObject();
        return gameObject.AddComponent<MinningMachine>();
    }
    [UnityTest]
    public IEnumerator MiningMachineInitStatusTest()
    {
        //arrange
        var machine = ArrangeMinningMachine();

        //执行代码
        var status = machine.Status;
        Debug.Log(status);
        yield return new WaitForFixedUpdate();
        status=machine.Status;

        //预期输出和实际输出
        Assert.AreEqual(machine.Status, MiningMachineStatus.Idle);
    }

    //对于矿机静止状态的旋转角度范围的测试，要求角度范围[-80,80]
    [UnityTest]
    public IEnumerator HookIdleRorationSpeedTestWithEnumeratorPasses()
    {
        MinningMachine machine = ArrangeMinningMachine();
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
