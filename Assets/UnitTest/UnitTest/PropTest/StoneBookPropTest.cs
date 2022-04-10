using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class StoneBookPropTest
{
    [UnityTest]
    public IEnumerator StoneBookPropTestSimplePasses()
    {
        GameObject go = new GameObject();
        go.AddComponent<PlayerDataMgr>();
        yield return new WaitForFixedUpdate();
        StoneBookProp bookProp = new StoneBookProp();
        Treasure treasure = TreasurePool.GetTreasure(TreasureID.MinStone).GetComponent<Treasure>();
        int score1 = PlayerDataMgr.Instance.Score;
        bookProp.OnGrab(treasure);
        int score2 = PlayerDataMgr.Instance.Score;
        Assert.AreEqual(score1+treasure.Score, score2);
        GameObject.Destroy(go);
    }
}
