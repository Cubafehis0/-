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

        //ִ�д���
        var status = machine.Status;
        Debug.Log(status);
        yield return new WaitForFixedUpdate();
        status=machine.Status;

        //Ԥ�������ʵ�����
        Assert.AreEqual(machine.Status, MiningMachineStatus.Idle);
    }

    //���ڿ����ֹ״̬����ת�Ƕȷ�Χ�Ĳ��ԣ�Ҫ��Ƕȷ�Χ[-80,80]
    [UnityTest]
    public IEnumerator HookIdleRorationSpeedTestWithEnumeratorPasses()
    {
        MinningMachine machine = ArrangeMinningMachine();
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
