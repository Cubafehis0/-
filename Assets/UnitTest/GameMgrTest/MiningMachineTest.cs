using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
public class MiningMachineTest : MonoBehaviour
{
    private GameObject go;
    private MiningMachine c;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        go = new GameObject();
        var player = go.AddComponent<PlayerDataMgr>();
        go.AddComponent<SoundManager>();
        go.AddComponent<MusicManager>();
        go.AddComponent<AudioListener>();
        go.AddComponent<GameControl>();
        GameObject go1=new GameObject();
        c=go1.AddComponent<MiningMachine>();
        yield return new WaitForFixedUpdate();
        player.Init();
    }
    [UnityTearDown]
    public IEnumerator TearDown()
    {
        GameObject.Destroy(c.gameObject);
        GameObject.Destroy(go);
        yield return null;
    }

    [Test]
    public void StateMachineTC0()
    {
        Assert.AreEqual(MiningMachineStatus.Idle, c.Status);
    }


    [Test]
    public void StateMachineTC1()
    {
        c.Status = MiningMachineStatus.Idle;
        Debug.Log(c == null);
        c.hookTrigger = true;
        c.UpdateStateMachine();
        Assert.AreEqual(MiningMachineStatus.Drop, c.Status);
    }

    [Test]
    public void StateMachineTC2()
    {
        c.Status = MiningMachineStatus.Idle;
        c.UpdateStateMachine();
        Assert.AreEqual(MiningMachineStatus.Idle, c.Status);
    }

    [Test]
    public void StateMachineTC3()
    {
        c.Status = MiningMachineStatus.Drop;
        c.HookLength = 1f;
        c.UpdateStateMachine();
        Assert.AreEqual(MiningMachineStatus.Drop, c.Status);
    }

    [Test]
    public void StateMachineTC4()
    {
        c.Status = MiningMachineStatus.Drop;
        c.HookLength = 300f;
        c.UpdateStateMachine();
        Assert.AreEqual(MiningMachineStatus.Drag, c.Status);
    }

    [Test]
    public void StateMachineTC5()
    {
        c.Status = MiningMachineStatus.Drop;
        c.reachItemTrigger = true;
        c.UpdateStateMachine();
        Assert.AreEqual(MiningMachineStatus.Drag, c.Status);;
    }

    [Test]
    public void StateMachineTC6()
    {
        c.Status = MiningMachineStatus.Drag;
        c.HookLength = 1f;
        c.UpdateStateMachine();
        Assert.AreEqual(MiningMachineStatus.Drag, c.Status);
    }

    [Test]
    public void StateMachineTC7()
    {
        c.Status = MiningMachineStatus.Drag;
        c.HookLength = 0.4f;
        c.UpdateStateMachine();
        Assert.AreEqual(MiningMachineStatus.Idle, c.Status);
    }

    [Test]
    public void StateMachineTC8()
    {
        c.Status = MiningMachineStatus.Drag;
        c.HookLength = 0.4f;
        c.DragTreasure = null;
        c.UpdateStateMachine();
        Assert.AreEqual(null,c.DragTreasure);
    }

    [Test]
    public void StateMachineTC9()
    {
        c.Status = MiningMachineStatus.Drag;
        c.HookLength = 0.4f;
        c.DragTreasure = TreasurePool.GetTreasure(TreasureID.MinStone).GetComponent<Treasure>();
        c.UpdateStateMachine();
        Assert.AreEqual(null, c.DragTreasure);
    }
}
