using System;
using System.Collections.Generic;
using UnityEngine;
public class TreasurePool
{
    public static GameObject GetTreasure(TreasureID id)
    {
        GameObject go = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Treasures/" + id.ToString()));
        go.name = id.ToString();
        go.transform.parent = null;
        return go; 
    }
    public static void Destory(GameObject go)
    {
        GameObject.Destroy(go);
    }
}
