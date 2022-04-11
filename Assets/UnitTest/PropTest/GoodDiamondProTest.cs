using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class GoodDiamondProTest
{
    GameObject go;
    GoodDiamondProp prop;
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
        prop = new GoodDiamondProp();
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
    public void GoodDiamondPropTestSimplePasses1()
    {
        Treasure treasure = TreasurePool.GetTreasure(TreasureID.Diamond).GetComponent<Treasure>();
        int score1 = PlayerDataMgr.Instance.Score;
        prop.OnGrab(treasure);
        int score2 = PlayerDataMgr.Instance.Score;
        Assert.AreEqual(score1 + treasure.Score*0.15, score2);
    }
    [Test]
    public void GoodDiamondPropTestSimplePasses2()
    {
        Treasure treasure = TreasurePool.GetTreasure(TreasureID.Mouse).GetComponent<Treasure>();
        int score1 = PlayerDataMgr.Instance.Score;
        prop.OnGrab(treasure);
        int score2 = PlayerDataMgr.Instance.Score;
        Assert.AreEqual(score1, score2);
    }
}
