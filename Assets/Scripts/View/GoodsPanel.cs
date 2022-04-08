using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UIFramework;
using UnityEngine.UI;
public class GoodsPanelContext:BaseContext
{
    public GoodsID goodsID;
    public int price;
    public GoodsPanelContext(UIType type,GoodsID id,int price):base(type)
    {
        this.goodsID = id;
        this.price = price;
    }
}

public class GoodsPanel : BaseView
{
    [SerializeField]
    private Text priceText;
    [SerializeField]
    private Image propImage;


    public override void OnEnter(BaseContext context)
    {
        base.OnEnter(context);
        GoodsPanelContext goodsContext=context as GoodsPanelContext;

    }

    private void SetPriceText(int price)
    {
        priceText.text=price.ToString();
    }
    private void SetPropImage(GoodsID id)
    {

    }
}
