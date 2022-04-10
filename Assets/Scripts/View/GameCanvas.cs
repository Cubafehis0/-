using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class GameCanvasContext : BaseContext
{
    public int Level
    {
        get => PlayerDataMgr.Instance.PlayLV;
    }
    public TreasureidIntSerializableDictionary TreasureInfo
    {
        get => GameControl.Instance.LevelInfo.treasureInfo;
    }
    public int TargetScore
    {
        get => GameControl.Instance.TargetScore;
    }
    public int Time
    {
        get => GameControl.Instance.LeftTime;
    }
    public int Score
    {
        get => PlayerDataMgr.Instance.Score;
    }
    public GameCanvasContext(UIType type) : base(type)
    {
    }
}
public class GameCanvas : BaseView
{
    [SerializeField]
    private Text levelText;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text targetScoreText;
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Text bombCntText;
    [SerializeField]
    private Vector2 startPos;
    [SerializeField]
    private Vector2 endPos;
    [SerializeField]
    private float treasureDis;
    List<GameObject> treasures = new List<GameObject>();
    UnityAction SetBomb;
    public override void OnEnter(BaseContext context)
    {
        MusicManager.Instance.PlayMusic("Game");
        GameCanvasContext gameContext = context as GameCanvasContext;
        SetLevelText(gameContext.Level);
        SetTargetScoreText(gameContext.TargetScore);
        SetTimer(gameContext.Time);
        SetScore(gameContext.Score);
        InitTreasures(gameContext.TreasureInfo);
        SetBombCnt(PlayerDataMgr.Instance.GetPropCnt(PropID.Bomb));
        PlayerDataMgr.Instance.OnScoreChanged.AddListener(SetScore);
        GameControl.Instance.OnTimeChanged.AddListener(SetTimer);
        SetBomb = delegate
        {
            SetBombCnt(PlayerDataMgr.Instance.GetPropCnt(PropID.Bomb));
        };
        PlayerDataMgr.Instance.OnPropListChanged.AddListener(SetBomb);
    }
    public override void OnExit(BaseContext context)
    {
        PlayerDataMgr.Instance.OnScoreChanged.RemoveListener(SetScore);
        GameControl.Instance.OnTimeChanged.RemoveListener(SetTimer);
        PlayerDataMgr.Instance.OnPropListChanged.RemoveListener(SetBomb);
    }


    private void InitTreasures(TreasureidIntSerializableDictionary treasureInfo)
    {
        foreach (var pair in treasureInfo)
        {
            for (int i = 0; i < pair.Value; i++)
            {
                GameObject treasure = TreasurePool.GetTreasure(pair.Key);
                treasures.Add(treasure);
            }
        }
        while (!RandomTreasurePos(treasures)) ;
    }

    private bool RandomTreasurePos(List<GameObject> treasures)
    {
        int cnt = 0;
        for(int i = 0; i < treasures.Count; i++)
        {
            bool repeat = true;
            Vector2 pos = Vector2.zero;
            while(repeat)
            {
                cnt++;
                if (cnt >= 100) return false;
                pos = RandomVector();
                repeat = false;
                for (int j = 0; j < i; j++)
                {
                    Vector2 p = treasures[j].transform.position;
                    if (Vector2.Distance(p, pos) < treasureDis)
                    {
                        repeat = true;
                        break;
                    }
                }
            }
            treasures[i].transform.position = pos;           
        }
        return true;
    }
    Vector2 RandomVector()
    {
        float x= UnityEngine.Random.Range(startPos.x, endPos.x);
        float y= UnityEngine.Random.Range(startPos.y, endPos.y);
        return new Vector2(x, y);
    }
    
    private void SetLevelText(int level)
    {
        levelText.text = level.ToString();
    }
    private void SetTargetScoreText(int targetScore)
    {
        targetScoreText.text = targetScore.ToString();
    }
    private void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
    private void SetTimer(int time)
    {
        timerText.text = time.ToString();
    }
    private void SetBombCnt(int cnt)
    {
        bombCntText.text =cnt.ToString();
    }
}
