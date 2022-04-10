using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework;
using Singleton;
using UnityEngine.UI;

public class ShopCanvasContext:BaseContext
{
    public List<KeyValuePair<PropID, int>> propInfos;
    public int Score
    {
        get => PlayerDataMgr.Instance.Score;
    }
    public ShopCanvasContext(UIType type):base(type)
    {
        propInfos = ShopArrange.GetShopGoods();
    }
}
public class ShopCanvas : AnimateView
{
    [SerializeField] Vector2 startPos;
    [SerializeField] float interval;
    [SerializeField] GameObject prop;
    [SerializeField] Text tipText;
    [SerializeField] Text scoreText;
    [SerializeField] Image mask;
    bool hasShop=false;

    public void Shop()
    {
        hasShop = true;
    }
    // Start is called before the first frame update
    
    public override void OnEnter(BaseContext context)
    {
        base.OnEnter(context);

        MusicManager.Instance.PlayMusic("Shop");
        var infos = (context as ShopCanvasContext).propInfos;
        SetScore((context as ShopCanvasContext).Score);
        PlayerDataMgr.Instance.OnScoreChanged.AddListener(SetScore);
        for (int i = 0; i < infos.Count; i++)
        {
            var info = infos[i];
            var p = GameObject.Instantiate(prop);
            p.transform.SetParent(transform);
            p.transform.localPosition = new Vector2(interval * i, 0) + startPos;
            GoodsPanel gp=p.GetComponent<GoodsPanel>();
            gp.OnEnter(new GoodsPanelContext(UIType.GoodsPanel, info.Key, info.Value,tipText,Shop));
        }
    }
    public override void OnExit(BaseContext context)
    {
        PlayerDataMgr.Instance.OnScoreChanged.RemoveListener(SetScore);
    }
    private void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void Click2Next()
    {
        SoundManager.Instance.PlayMusic("BtnClick");
        PlayerDataMgr.Instance.NextTurn();
        mask.gameObject.SetActive(true); 
        if (hasShop)
            _animator.SetTrigger("Happy");
        else
            _animator.SetTrigger("Angry");
        StartCoroutine("WaitLoad");
    }
    IEnumerator WaitLoad()
    {
        yield return new WaitForSeconds(1);
        SceneJump.Instance.Jump(SceneType.Game);
    }
}
