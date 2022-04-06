using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<TextAsset> levelJsons;

    private List<LevelData> levelDatas;

    private static LevelManager instance;
    public static LevelManager Instance { get => instance; }
    private int level=0;
    public int Level { get { return level; } }
    public LevelData GetNowLevelData()
    {
        if(levelDatas.Count>level)
        {
            return levelDatas[level]; ;
        }
        else
        {
            throw new Exception("关卡数量不够");
        }
    }

    void Awake()
    {
        Destroy(instance);
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        levelDatas = levelJsons.Select(x => JsonUtility.FromJson<LevelData>(x.text)).ToList();
        level = 0;
    }
}
