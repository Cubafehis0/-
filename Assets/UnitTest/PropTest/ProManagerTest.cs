using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ProManagerTest
{
    [Test]
    public void ProManagerTestSimplePasses1()
    {
        PropRemoveType id= PropManager.GetPropRemoveType(PropID.LuckGress);
        Assert.AreEqual(id, PropRemoveType.OnTurnEnd);
    }
    [Test]
    public void ProManagerTestSimplePasses2()
    {
        PropRemoveType id = PropManager.GetPropRemoveType(PropID.Bomb);
        Assert.AreEqual(id, PropRemoveType.AfterUse);
    }
    [Test]
    public void ProManagerTestSimplePasses3()
    {
        PropUseType id = PropManager.GetPropUseType(PropID.Bomb);
        Assert.AreEqual(id, PropUseType.Hand);
    }
    [Test]
    public void ProManagerTestSimplePasses4()
    {
        PropUseType id = PropManager.GetPropUseType(PropID.LuckGress);
        Assert.AreEqual(id, PropUseType.Auto);
    }
}
