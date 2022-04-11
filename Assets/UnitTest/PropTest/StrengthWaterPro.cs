using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StrengthWaterPropTest
{
    GameObject go;
    IProp prop;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        go = new GameObject();
        var player = go.AddComponent<PlayerDataMgr>();
        go.AddComponent<SoundManager>();
        go.AddComponent<MusicManager>();
        go.AddComponent<AudioListener>();
        go.AddComponent<GameControl>();
        yield return new WaitForFixedUpdate();
        prop = new StrengthWaterProp();
        player.Init();
    }

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        GameObject.Destroy(go);
        prop = null;
        yield return null;
    }


    [Test]
    public void StrengtnWaterPropTestSimplePasses1()
    {
        double speed1 = MiningMachine.SpeedFactor;
        prop.Use();
        double speed2 = MiningMachine.SpeedFactor;
        Assert.AreEqual(2*speed1 , speed2);
    }

    [Test]
    public void StrengtnWaterPropTestSimplePasses2()
    {
        double speed1 = MiningMachine.SpeedFactor;
        prop.OnRemove();
        double speed2 = MiningMachine.SpeedFactor;
        Assert.AreEqual(speed1, 2 * speed2);
    }
}