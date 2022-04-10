using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class ShopArrange
{
    // Start is called before the first frame update
    private static int rate2 = 50;//生成价格区间长度
    //道具编号及其价格
    public static List<KeyValuePair<PropID, int>> GetShopGoods()
    {
        List<KeyValuePair<PropID, int>> valuePairs = new List<KeyValuePair<PropID, int>>();
        int[] shopGoods = new int[] { 1, 2, 3, 4, 5 };
        int[] money = new int[] { 0, 1, 2, 3, 4 };
        int[] shopGoodsRandom = GetGoodsRandom(shopGoods);//道具的乱序5个道具
        int[] moneyRandom = GetGoodsmoneyRandom(rate2,money);//价格的乱序 5个区间
        for(int i = 0; i < 5; i++)//生成5个道具及其价格
        {
            valuePairs.Add(new KeyValuePair<PropID, int>((PropID)shopGoodsRandom[i], moneyRandom[i]));
        }
        return valuePairs;
    }
    private static int[] GetGoodsRandom(int[] shopGoods)//打乱道具或价格顺序
    {
        for(int i = 0; i < shopGoods.Length; i++)
        {
            int tmp = shopGoods[i];
            int index = Random.Range(0, shopGoods.Length);
            shopGoods[i] = shopGoods[index];
            shopGoods[index] = tmp;
        }
        return shopGoods;
    }

    private static int[] GetGoodsmoneyRandom(int rate2,int[] money)//生成一组5个范围的价格对应5个道具
    {
        for(int i = 0; i < money.Length; i++)
        {
            int k = money[i]*rate2;
            money[i] = Random.Range(k, k + rate2);
        }
        return GetGoodsRandom(money);//乱序道具价格
    }
}
