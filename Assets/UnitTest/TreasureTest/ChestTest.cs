using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;
using NUnit.Framework;
public class ChestTest
{
    Chest chest;
    GameObject go;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        go = new GameObject();
        var player=go.AddComponent<PlayerDataMgr>();
        chest = TreasurePool.GetTreasure(TreasureID.Chest).GetComponent<Chest>();
        yield return new WaitForFixedUpdate();
        player.Init();
    }
    [UnityTearDown]
    public IEnumerator TearDown()
    {
        GameObject.Destroy(chest.gameObject); 
        GameObject.Destroy(go);
        yield return null;
    }
    [Test]
    public void ChestTestPass0()
    {
        int score1 = PlayerDataMgr.Instance.Score;
        chest.GetRandomReward(0);
        int score2 = PlayerDataMgr.Instance.Score;
        UnityEngine.Assertions.Assert.AreEqual(score2, score1 + 500);
    }

    [Test]
    public void ChestTestPass1()
    {
        int score1 = PlayerDataMgr.Instance.Score;
        chest.GetRandomReward(1);
        int score2 = PlayerDataMgr.Instance.Score;
        UnityEngine.Assertions.Assert.AreEqual(score2, score1 + 100);
    }

    [Test]
    public void ChestTestPass2()
    {
        int count1 = PlayerDataMgr.Instance.GetPropCnt(PropID.StrengthWater);
        chest.GetRandomReward(2);
        int count2 = PlayerDataMgr.Instance.GetPropCnt(PropID.StrengthWater);
        UnityEngine.Assertions.Assert.AreEqual(count1+1, count2);
    }

    [Test]
    public void ChestTestPass3()
    {
        int count1 = PlayerDataMgr.Instance.GetPropCnt(PropID.StoneBook);
        chest.GetRandomReward(3);
        int count2 = PlayerDataMgr.Instance.GetPropCnt(PropID.StoneBook);
        UnityEngine.Assertions.Assert.AreEqual(count1 + 1, count2);
    }

    [Test]
    public void ChestTestPass4()
    {
        int count1 = PlayerDataMgr.Instance.GetPropCnt(PropID.GoodDiamond);
        chest.GetRandomReward(4);
        int count2 = PlayerDataMgr.Instance.GetPropCnt(PropID.GoodDiamond);
        UnityEngine.Assertions.Assert.AreEqual(count1 + 1, count2);
    }
}
