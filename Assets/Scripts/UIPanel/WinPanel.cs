using UnityEngine;
using UnityEngine.UI;

public class WinPanel : PanelBase
{

    public static WinPanel instance;

    public Text score;

    public GameObject[] Stars;

    public override void Init(params object[] args)
    {
        base.Init(args);
        layer = PanelLayer.Panel;
        instance = this;
        score.text = EntityManager.Instance.GetPlayerMinerEntity().score.ToString();
        int starCount = EntityManager.Instance.GetPlayerMinerEntity().starCount;
        SetStarNumber(starCount);

        int GateLevel = PlayerPrefs.GetInt("DB_GateLevel");
        if (GateLevel == PlayerDataMgr.Instance.PlayLV)
        {
            GateLevel++;
            PlayerPrefs.SetInt("DB_GateLevel", GateLevel);
        }



    }

    public void SetStarNumber(int value)
    {
        for (int i = 0; i < 3; i++)
        {
            Stars[i].SetActive(false);
        }
        for (int i = 0; i < value; i++)
        {
            Stars[i].SetActive(true);
        }
    }

    public override void OnShowing()
    {
        base.OnShowing();

    }

    public void OnLVButton()
    {
        //SoundManager.instance.PlayBtn();
        //SceneJump.instance.Jump(SceneType.Map);
    }

    public void OnReplayButton()
    {
        SoundManager.instance.PlayBtn();
        SceneJump.instance.Jump(SceneType.Game);
    }

    public void OnNextButton()
    {
        SoundManager.instance.PlayBtn();
        PlayerDataMgr.Instance.PlayLV++;
        SceneJump.instance.Jump(SceneType.Game);
    }
}
