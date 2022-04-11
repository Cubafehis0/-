
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;
using NUnit.Framework;

public class TNTTreasureTest
{
    [Test]
    public void TNTTreasureTestPass()
    {
        TNTTreasure treasure = TreasurePool.GetTreasure(TreasureID.TNT).GetComponent<TNTTreasure>();
        treasure.SetTag(treasure.gameObject, "Destory");
        UnityEngine.Assertions.Assert.AreEqual(treasure.gameObject.tag, "Destory");
    }
}
