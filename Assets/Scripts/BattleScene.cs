﻿using System;
using UnityEngine;

public class BattleScene : MonoBehaviour
{
    PlayerMiner playerMiner;

    void Start()
    {
        int level = DataManager.instance.PlayLV;
        LevelData levelData = LevelManager.Instance.GetNowLevelData();
        LoadTreasures(levelData.treasureInfo);
        //loadPlayerMiner();


        //initLevelEntity(level, levelDatas);
        //initPlayerEntity();
        //loadBattleCanvas(level, levelDatas[0]);
        //loadWall();
    }

    private void LoadTreasures(TreasureidIntSerializableDictionary treasuresInfo)
    {
        GameObject treasures = new GameObject("Treasures");
        treasures.transform.SetParent(transform, false);
        foreach(var treasureInfo in treasuresInfo)
        {
            TreasureID id=(TreasureID)treasureInfo.Key;
            for(int i=0;i<treasureInfo.Value;i++)
            {
                GameObject treasure = TreasurePool.Instance.GetTreasure(id);
                treasure.transform.parent = treasures.transform;
            }
        }
    }

    void Update()
    {
        if (!EntityManager.Instance.GetLevelEntity().isPause)
        {
            playerMiner.UpdateProcess();
            if (Input.GetKeyDown(KeyCode.A))
                BattleCanvas.Instance.AddScoreStar();
        }
    }


    //void initLevelEntity(int level, LevelData[] levelDatas)
    //{
    //    var levelEntity = EntityManager.Instance.GetLevelEntity();
    //    levelEntity.levelDatas = levelDatas;
    //    levelEntity.level = level;
    //    levelEntity.isPause = false;
    //    levelEntity.isTimeOrStep = levelDatas[0].isTimeOrStep == "0" ? true : false;
    //    levelEntity.timeStep = Convert.ToInt32(levelDatas[0].timeStep);
    //    levelEntity.passScore = Convert.ToInt32(levelDatas[0].target1.Split(',')[1]);
    //    levelEntity.perAddStarScore = Convert.ToInt32(levelDatas[0].target2.Split(',')[1]);
    //}


    //void initPlayerEntity()
    //{
    //    var playerEntity = EntityManager.Instance.GetPlayerMinerEntity();
    //    playerEntity.score = 0;
    //    playerEntity.rewardDiamond = 0;
    //}


    //void loadBattleCanvas(int level, LevelData levelData)
    //{
    //    BattleCanvas battleCanvas = BattleCanvas.Instance;
    //    battleCanvas.transform.SetParent(transform, false);
    //    battleCanvas.SetLevelText(level);

    //    if (level % 30 < 10)
    //        battleCanvas.SetBgImage("GameMain_1_bg");
    //    else if (level % 30 < 20)
    //        battleCanvas.SetBgImage("GameMain_2_bg");
    //    else if (level % 30 < 30)
    //        battleCanvas.SetBgImage("GameMain_3_bg");
    //    string[] target1datas = levelData.target1.Split(',');
    //    string[] target2datas = levelData.target2.Split(',');
    //    if (levelData.isTimeOrStep == "0")
    //    {
    //        if (target2datas[0] == "-2")
    //            battleCanvas.SetScoreTipPanel("ScoreTip1");
    //        else if (target2datas[0] == "11")
    //            battleCanvas.SetScoreTipPanel("ScoreTip3");
    //        else
    //            Debug.LogError("invalid target2datas[0]");


    //        battleCanvas.SetProp1Image("propTimeUp");
    //        battleCanvas.SetProp2Image("propStopBaby");
    //        battleCanvas.SetProp3Image("propBomb");

    //        battleCanvas.SetProp1Count(PlayerData.GetGameProps(GameProps.TimeUp));
    //        battleCanvas.SetProp2Count(PlayerData.GetGameProps(GameProps.StopBaby));
    //        battleCanvas.SetProp3Count(PlayerData.GetGameProps(GameProps.Bomb));
    //    }
    //    else if (levelData.isTimeOrStep == "1")
    //    {
    //        if (target2datas[0] == "-2")
    //            battleCanvas.SetScoreTipPanel("ScoreTip2");
    //        else if (target2datas[0] == "11")
    //            battleCanvas.SetScoreTipPanel("ScoreTip4");
    //        else
    //            Debug.LogError("invalid target2datas[0]");


    //        battleCanvas.SetProp1Image("propStepUp");
    //        battleCanvas.SetProp2Image("propStopBaby");
    //        battleCanvas.SetProp3Image("propBomb");

    //        battleCanvas.SetProp1Count(PlayerData.GetGameProps(GameProps.StepUp));
    //        battleCanvas.SetProp2Count(PlayerData.GetGameProps(GameProps.StopBaby));
    //        battleCanvas.SetProp3Count(PlayerData.GetGameProps(GameProps.Bomb));
    //    }
    //    else
    //        Debug.LogError("invalid levelData.isTimeOrStep");


    //    if (target2datas[0] == "11")
    //    {
    //        battleCanvas.GetScoreTipPanel().SetTarget2Icon("RescueObject_type11");
    //        battleCanvas.GetScoreTipPanel().SetTarget2Text(target2datas[1]);
    //    }

    //    battleCanvas.GetScoreTipPanel().SetTimeOrStep(Convert.ToInt32(levelData.timeStep));
    //    battleCanvas.GetScoreTipPanel().SetScoreText("0 / " + target1datas[1]);
    //}


    //void loadTreasures(LevelData[] levelDatas)
    //{
        
    //}


    //void loadWall()
    //{
    //    GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Wall"), transform, false);
    //}


    //void loadPlayerMiner()
    //{
    //    playerMiner = GameObject.Instantiate(Resources.Load<PlayerMiner>("Prefabs/PlayerMiner"));
    //    playerMiner.transform.position = new Vector3(0, Camera.main.orthographicSize - 1.1f, 0);
    //    playerMiner.transform.SetParent(transform);
    //    BattleCanvas.Instance.AddMinerControlDetector(playerMiner);
    //}
}
