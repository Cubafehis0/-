using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MiningMachineIdleTest
{
    private static MiningMachine ArrangeMinningMachine()
    {
        GameObject gameObject = new GameObject();
        return gameObject.AddComponent<MiningMachine>();

    }
    // A Test behaves as an ordinary method
    //[Test]
    //public void HookIdleTestSimplePasses()
    //{
    //    var machine=ArrangeMinningMachine();
    //    machine.Input(KeyCode.DownArrow);
    //    MiningMachineStatus statuc = machine.Status;
    //    Assert.AreEqual(machine.Status, MiningMachineStatus.Drop);
    //}
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.

    //对于矿机初始状态的测试，初始应为静止状态
    [Test]
    public void MiningMachineInitStatusTest()
    {
        var machine = ArrangeMinningMachine();
        var status = machine.Status;
        Assert.AreEqual(machine.Status, MiningMachineStatus.Idle);
    }

    //对于矿机静止状态的旋转角度范围的测试，要求角度范围[-80,80]
    [UnityTest]
    public IEnumerator HookIdleRorationSpeedTestWithEnumeratorPasses()
    {
        GameObject gameObject = new GameObject();
        MiningMachine machine = gameObject.AddComponent<MiningMachine>();
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
