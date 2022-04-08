using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework;
using UnityEngine.UI;
using System;

public class GameCanvasContext:BaseContext
{
    public PlayerDataMgr playerData;
    public int Level
    {
        get => playerData.PlayLV;
    }
    public TreasureidIntSerializableDictionary TreasureInfo
    {
        get => playerData.TreasureInfo;
    }
    public int TargetScore
    {
        get => playerData.TargetScore;
    }
    public int Time
    {
        get => playerData.LeftTime;
    }
    public int Score
    {
        get=>playerData.Score;
    }
    public GameCanvasContext(UIType type):base(type)
    {
        playerData = PlayerDataMgr.Instance;
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
    public override void OnEnter(BaseContext context)
    {
        GameCanvasContext gameContext = context as GameCanvasContext;
        SetLevelText(gameContext.Level);
        SetTargetScoreText(gameContext.TargetScore);
        SetTimer(gameContext.Time);
        SetScore(gameContext.Score);
        gameContext .playerData.OnScoreChanged.AddListener(SetScore);
        gameContext.playerData.OnTimeChanged.AddListener(SetTimer);
    }
    public override void OnExit(BaseContext context)
    {

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

}
