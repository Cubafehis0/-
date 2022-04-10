using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UIFramework;
using Singleton;
public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameControl Instance;
    private float leftTime;
    public bool isGaming;
    [HideInInspector] public UnityEvent<int> OnTimeChanged;
    [HideInInspector] public UnityEvent OnTurnStart;
    [HideInInspector] public UnityEvent OnTurnEnd;
    [HideInInspector] public UnityEvent OnUpdate;
    public LevelData LevelInfo{
        get;set;
    }
    public int LeftTime
    {
        get => Mathf.CeilToInt(leftTime);
        private set
        {
            OnTimeChanged?.Invoke(LeftTime);
        }
    }
    public int TargetScore{
        get;set;
    }
    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        OnTurnStart = new UnityEvent();
        OnTimeChanged=new UnityEvent<int>();
        OnTurnEnd = new UnityEvent();
        OnUpdate=new UnityEvent();
        DontDestroyOnLoad(gameObject);
    }
    public void Start()
    {
        OnTurnStart.AddListener(PlayerDataMgr.Instance.TurnStart);
        OnTurnEnd.AddListener(PlayerDataMgr.Instance.TurnEnd);
    }
    public void TurnEnd()
    {
        OnTurnEnd?.Invoke();
        isGaming = false;
        if(PlayerDataMgr.Instance.Score>=TargetScore)
        {
            if(PlayerDataMgr.Instance.PlayLV>=LevelDataMgr.Instance.LevelCount)
            {
                Singleton<ContextManager>.Instance.Push(new WinPanelContext(UIType.WinPanel));
            }
            else SceneJump.Instance.Jump(SceneType.Shop);
        }
        else
        {
            Singleton<ContextManager>.Instance.Push(new BaseContext(UIType.LosePanel));
        }
    }
    public void TurnStart()
    {
        isGaming=true;
        OnTurnStart?.Invoke();
        LevelInfo = LevelDataMgr.Instance.GetLevelInfo(PlayerDataMgr.Instance.PlayLV);
        leftTime = LevelInfo.time;
        TargetScore =LevelInfo.targetScore;
    }
    void Update()
    {
        if (isGaming)
        {
            OnUpdate?.Invoke();
            leftTime -= Time.deltaTime;
            LeftTime = Mathf.CeilToInt(leftTime);
            if (leftTime <= 0)
            {
                TurnEnd();
            }
        }
    }
}