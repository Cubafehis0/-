using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDataMgr : MonoBehaviour
{

    public static PlayerDataMgr Instance;


    private List<LevelData> levelsData = new List<LevelData>();
    /// <summary>
    /// 玩家要玩的关卡
    /// </summary>
    public int PlayLV = 1;
    public bool IsFinished
    {
        get => PlayLV ==levelsData.Count;
    }
    public int Score
    {
        get => score;
        set
        {
            score = value;
            OnScoreChanged?.Invoke(Score);
        }
    }
    public int LeftTime
    {
        get => Mathf.CeilToInt(leftTime);
        private set
        {
            OnTimeChanged?.Invoke(LeftTime);
        }
    }
    public int TargetScore
    {
        get => targetScore;
    }

    [HideInInspector]
    public UnityEvent<int> OnScoreChanged;
    [HideInInspector]
    public UnityEvent<int> OnTimeChanged;
    public TreasureidIntSerializableDictionary TreasureInfo
    {
        get => LevelInfo.treasureInfo;
    }
    private LevelData LevelInfo
    {
        get => levelsData[PlayLV - 1];
    }
    /// <summary>
    /// 游戏选择道具列表
    /// </summary>
    public List<GoodsID> playGamePropsList = new List<GoodsID>();

    void FixedUpdate()
    {
        leftTime -= Time.deltaTime;
        LeftTime = Mathf.CeilToInt(leftTime);
    }
    public void GameStart()
    {
        leftTime = LevelInfo.time;
        LeftTime = Mathf.CeilToInt(leftTime);
    }
    private int score;
    private float leftTime;
    private int targetScore;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        OnScoreChanged = new UnityEvent<int>();
        OnTimeChanged = new UnityEvent<int>();
        foreach (var json in Resources.LoadAll<TextAsset>("Levels"))
        {
            levelsData.Add(JsonUtility.FromJson<LevelData>(json.text));
        }
        levelsData.Sort((l, r) => l.level - r.level);
    }
    public void NewGame()
    {
        PlayLV = 1;
        score = 0;
        targetScore = LevelInfo.targetScore;
    }
    public void NextGame()
    {
        PlayLV++;
        targetScore = LevelInfo.targetScore;
    }
}
