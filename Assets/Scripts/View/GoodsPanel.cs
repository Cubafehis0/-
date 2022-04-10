using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework;
using UnityEngine.UI;
using UnityEngine.Events;

public class GoodsPanelContext : BaseContext
{
    public PropID goodsID;
    public int price;
    public Text tipText;
    public UnityEvent OnShop;
    public GoodsPanelContext(UIType type, PropID id, int price, Text tipText,UnityAction onShop) : base(type)
    {
        this.goodsID = id;
        this.price = price;
        this.tipText = tipText;
        OnShop = new UnityEvent();
        OnShop.AddListener(onShop);
    }
}

public class GoodsPanel : BaseView
{
    [SerializeField]
    private Text priceText;
    [SerializeField]
    private Image propImage;
    private int price;
    private PropID propID;
    private Text tipText;
    private UnityEvent OnShop;
    public override void OnEnter(BaseContext context)
    {
        base.OnEnter(context);
        GoodsPanelContext goodsContext = context as GoodsPanelContext;
        price = goodsContext.price;
        propID = goodsContext.goodsID;
        SetPriceText(goodsContext.price);
        SetPropImage(goodsContext.goodsID);
        tipText = goodsContext.tipText;
        OnShop = goodsContext.OnShop;
    }
    public void Click2Purchase()
    {
        Debug.Log("Click2Purchase");

        if (PlayerDataMgr.Instance.Score > price)
        {
            SoundManager.Instance.PlayMusic("Purchase");
            OnShop?.Invoke();
            PlayerDataMgr.Instance.AddProps(propID);
            PlayerDataMgr.Instance.Score-=price;
            Destroy(gameObject);
        }
        else
        {
            SoundManager.Instance.PlayMusic("NoMoney");
            ShowMessage("½ðÇ®²»×ã¡£");
        }
    } 
    public void ShowGoodsInfo()
    {
        ShowMessage(PropManager.GetPropInfo(propID));
    }
    public void ClearGoodsInfo()
    {
        ShowMessage("");
    }
    private void ShowMessage(string messgae)
    {
        if (tipText) tipText.text = messgae;
        else Debug.Log("¿Õ");
    }
    private void SetPriceText(int price)
    {
        priceText.text = price.ToString();
    }
    private void SetPropImage(PropID id)
    {
        Sprite sprite = Resources.Load<Sprite>("Textures/Prop/" + id.ToString());
        if (sprite != null)
            propImage.sprite = sprite;
    }
}
