using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class LuckyGrassPropTest
{
    [Test]
    public void LuckyGrassPropTestSimplePasses1()
    {
        LuckGrassProp LuckyGrass = new LuckGrassProp();
        LuckyGrass.Use();
        UnityEngine.Assertions.Assert.AreEqual(Chest.p,Chest.p2);
    }
    [Test]
    public void LuckyGrassPropTestSimplePasses2()
    {
        LuckGrassProp LuckyGrass = new LuckGrassProp();
        LuckyGrass.OnRemove();
        UnityEngine.Assertions.Assert.AreEqual(Chest.p, Chest.p1);
    }
}