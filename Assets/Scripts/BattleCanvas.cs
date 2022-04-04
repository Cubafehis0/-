using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class BattleCanvas : MonoBehaviour
{
#pragma warning disable CS0649 // 从未对字段“BattleCanvas.pauseButton”赋值，字段将一直保持其默认值 null
    [SerializeField] Button pauseButton;
#pragma warning restore CS0649 // 从未对字段“BattleCanvas.pauseButton”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“BattleCanvas.scoreTip”赋值，字段将一直保持其默认值 null
    [SerializeField] GameObject scoreTip;
#pragma warning restore CS0649 // 从未对字段“BattleCanvas.scoreTip”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“BattleCanvas.bgImage”赋值，字段将一直保持其默认值 null
    [SerializeField] Image bgImage;
#pragma warning restore CS0649 // 从未对字段“BattleCanvas.bgImage”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“BattleCanvas.prop1”赋值，字段将一直保持其默认值 null
    [SerializeField] GameObject prop1;
#pragma warning restore CS0649 // 从未对字段“BattleCanvas.prop1”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“BattleCanvas.prop2”赋值，字段将一直保持其默认值 null
    [SerializeField] GameObject prop2;
#pragma warning restore CS0649 // 从未对字段“BattleCanvas.prop2”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“BattleCanvas.prop3”赋值，字段将一直保持其默认值 null
    [SerializeField] GameObject prop3;
#pragma warning restore CS0649 // 从未对字段“BattleCanvas.prop3”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“BattleCanvas.diamondText”赋值，字段将一直保持其默认值 null
    [SerializeField] Text diamondText;
#pragma warning restore CS0649 // 从未对字段“BattleCanvas.diamondText”赋值，字段将一直保持其默认值 null
#pragma warning disable CS0649 // 从未对字段“BattleCanvas.levelText”赋值，字段将一直保持其默认值 null
    [SerializeField] Text levelText;
    [SerializeField] GameObject scoreFlowText;
    [SerializeField] GameObject scoreStarContainer;
    ScoreTipPanel scoreTipPanel;


    static BattleCanvas instance;
    static public BattleCanvas Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.Instantiate(Resources.Load<BattleCanvas>("Prefabs/UI/BattleCanvas"));
                instance.Init();
            }
            return instance;
        }
    }

    public void Init()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
        pauseButton.onClick.AddListener(OnClickPauseButton);

        if (EntityManager.Instance.GetLevelEntity().isTimeOrStep)
            InvokeRepeating("Countdown", 1, 1);
    }

    public void SetBgImage(string name)
    {
        bgImage.sprite = Resources.Load<Sprite>("Textures/" + name);
    }

    public void SetScoreTipPanel(string name)
    {
        if (scoreTipPanel != null)
            GameObject.Destroy(scoreTipPanel);

        scoreTipPanel = GameObject.Instantiate(Resources.Load<ScoreTipPanel>("Prefabs/UI/" + name), scoreTip.transform, false);
    }

    public ScoreTipPanel GetScoreTipPanel()
    {
        return scoreTipPanel;
    }


    public void SetLevelText(int level)
    {
        levelText.text = level.ToString();
    }

    public void SetDiamondText(int count)
    {
        diamondText.text = count.ToString();
    }

    public void SetProp1Image(string name)
    {
        prop1.transform
             .Find("Button")
             .GetComponent<Image>()
             .sprite = Resources.Load<Sprite>("Textures/" + name);
    }

    public void SetProp2Image(string name)
    {
        prop2.transform
              .Find("Button")
              .GetComponent<Image>()
              .sprite = Resources.Load<Sprite>("Textures/" + name);
    }

    public void SetProp3Image(string name)
    {
        prop3.transform
              .Find("Button")
              .GetComponent<Image>()
              .sprite = Resources.Load<Sprite>("Textures/" + name);
    }


    public void SetProp1Count(int count)
    {
        Text propText = prop1.transform.Find("Text").GetComponent<Text>();
        Image propPurImage = prop1.transform.Find("Image").GetComponent<Image>();

        if (count == 0)
        {
            propText.gameObject.SetActive(false);
            propPurImage.gameObject.SetActive(true);
        }
        else
        {
            propText.gameObject.SetActive(true);
            propPurImage.gameObject.SetActive(false);
        }

        propText.text = count.ToString();
    }

    public void SetProp2Count(int count)
    {
        Text propText = prop2.transform.Find("Text").GetComponent<Text>();
        Image propPurImage = prop2.transform.Find("Image").GetComponent<Image>();

        if (count == 0)
        {
            propText.gameObject.SetActive(false);
            propPurImage.gameObject.SetActive(true);
        }
        else
        {
            propText.gameObject.SetActive(true);
            propPurImage.gameObject.SetActive(false);
        }

        propText.text = count.ToString();
    }

    public void SetProp3Count(int count)
    {
        Text propText = prop3.transform.Find("Text").GetComponent<Text>();
        Image propPurImage = prop3.transform.Find("Image").GetComponent<Image>();

        if (count == 0)
        {
            propText.gameObject.SetActive(false);
            propPurImage.gameObject.SetActive(true);
        }
        else
        {
            propText.gameObject.SetActive(true);
            propPurImage.gameObject.SetActive(false);
        }

        propText.text = count.ToString();
    }

    public void AddScore(int socre)
    {
        var entityManager = EntityManager.Instance;
        var playerMinerEntity = entityManager.GetPlayerMinerEntity();
        playerMinerEntity.score += socre;

        string scoreText = playerMinerEntity.score + " / "
                             + EntityManager.Instance.GetLevelEntity().passScore;

        BattleCanvas.Instance.GetScoreTipPanel().SetScoreText(scoreText);
        BattleCanvas.Instance.AddScoreFlowText(socre);

        var levelEntity = entityManager.GetLevelEntity();
        if (playerMinerEntity.score >= levelEntity.passScore)
        {
            if (playerMinerEntity.starCount == 0)
                AddScoreStar();

            if (playerMinerEntity.starCount == 1 && playerMinerEntity.score >= levelEntity.passScore + levelEntity.perAddStarScore)
                AddScoreStar();

            if (playerMinerEntity.starCount == 2 && playerMinerEntity.score >= levelEntity.passScore + levelEntity.perAddStarScore * 2)
                AddScoreStar();
        }
    }


    public void AddMinerControlDetector(PlayerMiner playerMiner)
    {
        EventTrigger eventTrigger = bgImage.gameObject.GetComponent<EventTrigger>()
                                      ?? bgImage.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.callback.AddListener((BaseEventData data) =>
        {
            if (playerMiner.IsDropAble())
                playerMiner.Drop();
        });
        entry.eventID = EventTriggerType.PointerDown;
        eventTrigger.triggers.Add(entry);
    }


    public void AddScoreStar()
    {
        const float startX = -70f;
        const float startY = -63f;
        const float gapX = 70f;
        const float endY = 0f;
        int starCount = scoreStarContainer.transform.childCount;
        GameObject scoreStar = GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/UI/ScoreStar"));
        scoreStar.transform.position = new Vector3(startX + starCount * gapX, startY, 0);
        scoreStar.transform.SetParent(scoreStarContainer.transform, false);
        scoreStar.transform.DOLocalMoveY(endY, 1f).OnComplete(() =>
        {
            if (EntityManager.Instance.GetPlayerMinerEntity().starCount == 3)
            {
                PanelMgr.instance.OpenPanel<WinPanel>("");
                EntityManager.Instance.GetLevelEntity().isPause = true;
            }
        });

        ++EntityManager.Instance.GetPlayerMinerEntity().starCount;
    }


    void OnClickPauseButton()
    {
        pauseButton.transform.DOScale(1.08f, 0.1f).OnComplete(() =>
        {
            pauseButton.transform.DOScale(1f, 0.1f);
        });
        SoundManager.instance.PlayBtn();
        PanelMgr.instance.OpenPanel<PausePanel>("");
    }


    void AddScoreFlowText(int score)
    {
        FlowTextCreator.CreateScoreFlowText(scoreFlowText.transform.localPosition, score.ToString(), 15f, 0.4f)
                       .transform
                       .SetParent(transform, false);
    }


    void Countdown()
    {
        var levelEntity = EntityManager.Instance.GetLevelEntity();
        if (levelEntity.timeStep == 0)
        {
            if (EntityManager.Instance.GetPlayerMinerEntity().starCount == 0)
                PanelMgr.instance.OpenPanel<LosePanel>("");
            else
                PanelMgr.instance.OpenPanel<WinPanel>("");

            EntityManager.Instance.GetLevelEntity().isPause = true;
        }
        else
            scoreTipPanel.SetTimeOrStep(--levelEntity.timeStep);
    }
}

