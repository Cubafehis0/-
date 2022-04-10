using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

public interface IManager
{
    void TurnEnd();
    void TurnStart();
}


public class PlayerDataMgr : MonoBehaviour,IManager
{
    public static PlayerDataMgr Instance;
    public int PlayLV = 1;
    private int score;
    public int Score
    {
        get => score;
        set
        {
            score = value;
            OnScoreChanged?.Invoke(Score);
        }
    }
    public void NewGame()
    {
        OnScoreChanged.RemoveAllListeners();
        OnTurnEnd.RemoveAllListeners();
        OnPropListChanged.RemoveAllListeners();
        propsList = new Dictionary<PropID, int>()
        {
            {PropID.Bomb,0},
            {PropID.GoodDiamond,0},
            {PropID.LuckGress,0},
            {PropID.StrengthWater,0},
            {PropID.StoneBook,0},
        };
        PlayLV = 1;
        score = 0;
    }
    public void NextTurn()
    {
        PlayLV++;
    }

    [HideInInspector] public UnityEvent<int> OnScoreChanged;
    [HideInInspector] public UnityEvent OnTurnEnd;
    #region 道具相关
    Dictionary<PropID, int> propsList = new Dictionary<PropID, int>();
    [HideInInspector] public UnityEvent OnPropListChanged;
    public Dictionary<PropID, int> GetProps()
    {
        return propsList;
    }
    public bool ContainProp(PropID id)=> propsList[id] != 0;
    public void AddProps(PropID id)
    {
        propsList[id]++;
        OnPropListChanged?.Invoke();
    }
    public int GetPropCnt(PropID id)=>propsList[id];
    public void RemoveProp(PropID id)
    {
        propsList[id]--;
        OnPropListChanged?.Invoke();
    }
    public void UseProp(PropID id, params object[] args)
    {
        var prop = PropManager.CreateProp(id);
        prop.Use(args);
        if (PropManager.GetPropRemoveType(id) == PropRemoveType.AfterUse)
        {
            prop.OnRemove();
            RemoveProp(id);
        }
        else if (PropManager.GetPropRemoveType(id) == PropRemoveType.OnTurnEnd)
        {
            OnTurnEnd.AddListener(delegate { RemoveProp(id); prop.OnRemove(); });
        }
    }
    #endregion
    public void TurnEnd()
    {
        OnTurnEnd?.Invoke();
        OnTurnEnd.RemoveAllListeners();
    }
    public void TurnStart()
    {
        foreach(var prop in propsList)
        {
            if(PropManager.GetPropUseType(prop.Key)==PropUseType.Auto)
            {
                for (int i = 0; i < prop.Value; i++)
                    UseProp(prop.Key);
            }
        }
    }
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        OnScoreChanged = new UnityEvent<int>();
        OnTurnEnd = new UnityEvent();
        OnPropListChanged= new UnityEvent();
    }    
}
