using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;
using NUnit.Framework;

public class TreasureTest 
{
    Treasure treasure;
    GameObject go;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        go = new GameObject();
        var player = go.AddComponent<PlayerDataMgr>();
        go.AddComponent<SoundManager>();
        go.AddComponent<MusicManager>();
        go.AddComponent<AudioListener>();
        yield return new WaitForFixedUpdate();
        player.Init();
    }
    [UnityTearDown]
    public IEnumerator TearDown()
    {
        GameObject.Destroy(go);
        GameObject.Destroy(treasure.gameObject);
        yield return null;
    }
    [Test]
    public void MinGoldOnDragTest()
    {
        treasure = TreasurePool.GetTreasure(TreasureID.MinGold).GetComponent<Treasure>();
        int score1 = PlayerDataMgr.Instance.Score;
        treasure.OnDrag();
        int score2 = PlayerDataMgr.Instance.Score;
        UnityEngine.Assertions.Assert.AreEqual(score2, score1 + 100);
    }

    [Test]
    public void MidGoldOnDragTest()
    {
        treasure = TreasurePool.GetTreasure(TreasureID.MidGold).GetComponent<Treasure>();
        int score1 = PlayerDataMgr.Instance.Score;
        treasure.OnDrag();
        int score2 = PlayerDataMgr.Instance.Score;
        UnityEngine.Assertions.Assert.AreEqual(score2, score1 + 250);
    }

    [Test]
    public void BigGoldOnDragTest()
    {
        treasure = TreasurePool.GetTreasure(TreasureID.BigGold).GetComponent<Treasure>();
        int score1 = PlayerDataMgr.Instance.Score;
        treasure.OnDrag();
        int score2 = PlayerDataMgr.Instance.Score;
        UnityEngine.Assertions.Assert.AreEqual(score2, score1 + 500);
    }
}
