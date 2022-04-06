using System;
using System.Collections.Generic;
using UnityEngine;


public class TreasurePool:MonoBehaviour
{
    private static TreasurePool instance;

    public static TreasurePool Instance { get => instance; }
    private int maxPoolSize=8;
    private void Awake()
    {
        Destroy(instance);
        instance = this;
        DontDestroyOnLoad(gameObject);  
    }
    Dictionary<TreasureID,Queue<GameObject>> pool=new Dictionary<TreasureID,Queue<GameObject>>();
    Dictionary<TreasureID, int> treasureCnt=new Dictionary<TreasureID, int>();
    public GameObject GetTreasure(TreasureID id)
    {
        if (!pool.ContainsKey(id))
        {
            pool.Add(id, new Queue<GameObject>());
            treasureCnt.Add(id, 0);
        }
        Queue<GameObject> queue = pool[id];
        if (queue.Count == 0)
        {
            queue.Enqueue(Create(id));
            treasureCnt[id]++;
        }
        GameObject go=queue.Dequeue();
        go.transform.parent = null;
        go.SetActive(true);
        return go;
    }
    public void Recycle(GameObject go)
    {
        Treasure treasure=go.GetComponent<Treasure>();
        string id = go.name.Split('_')[0];
        TreasureID treasureID = (TreasureID)Enum.Parse(typeof(TreasureID), id);
        if (treasureCnt[treasureID] > maxPoolSize)
            Dispose(treasureID, go);
        else pool[treasureID].Enqueue(go);
    }
    void Dispose(TreasureID id, GameObject go)
    {
        treasureCnt[id]--;
        Destroy(go);
    }
    GameObject Create(TreasureID id)
    {
        GameObject go= GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Treasures/" + id.ToString()));
        go.transform.parent =  transform;
        go.name=id.ToString()+'_'+treasureCnt[id];
        go.SetActive(false);
        return go;
    }
}
