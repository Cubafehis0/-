using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.TestTools;
using NUnit.Framework;
public class MoveableTreasureTest
{
    MoveableTreasure treasure;
    GameObject go;
    [UnitySetUp]
    public IEnumerator SetUp()
    {
        go = new GameObject();
        var player = go.AddComponent<PlayerDataMgr>();
        go.AddComponent<SoundManager>();    
        go.AddComponent<MusicManager>();    
        go.AddComponent<AudioListener>();
        treasure = TreasurePool.GetTreasure(TreasureID.Mouse)
                                          .GetComponent<MoveableTreasure>();
        treasure.transform.position = Vector3.zero;
        yield return new WaitForFixedUpdate();
        player.Init();
    }
    [UnityTearDown]
    public IEnumerator TearDown()
    {
        GameObject.Destroy(treasure.gameObject);
        GameObject.Destroy(go);
        yield return null;
    }

    [Test]
    public void MoveableTreasureTestPass1()
    {
        Vector3 position1 = treasure.transform.position;
        treasure.Move();
        Vector3 position2 = treasure.transform.position;
        NUnit.Framework.Assert.AreEqual(Vector3.Distance(position2, position1), Time.deltaTime * 1.3f,0.1F);
    }
}
