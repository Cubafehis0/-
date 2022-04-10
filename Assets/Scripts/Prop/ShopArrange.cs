using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class ShopArrange
{
    // Start is called before the first frame update
    private static int rate2 = 50;//���ɼ۸����䳤��
    //���߱�ż���۸�
    public static List<KeyValuePair<PropID, int>> GetShopGoods()
    {
        List<KeyValuePair<PropID, int>> valuePairs = new List<KeyValuePair<PropID, int>>();
        int[] shopGoods = new int[] { 1, 2, 3, 4, 5 };
        int[] money = new int[] { 0, 1, 2, 3, 4 };
        int[] shopGoodsRandom = GetGoodsRandom(shopGoods);//���ߵ�����5������
        int[] moneyRandom = GetGoodsmoneyRandom(rate2,money);//�۸������ 5������
        for(int i = 0; i < 5; i++)//����5�����߼���۸�
        {
            valuePairs.Add(new KeyValuePair<PropID, int>((PropID)shopGoodsRandom[i], moneyRandom[i]));
        }
        return valuePairs;
    }
    private static int[] GetGoodsRandom(int[] shopGoods)//���ҵ��߻�۸�˳��
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

    private static int[] GetGoodsmoneyRandom(int rate2,int[] money)//����һ��5����Χ�ļ۸��Ӧ5������
    {
        for(int i = 0; i < money.Length; i++)
        {
            int k = money[i]*rate2;
            money[i] = Random.Range(k, k + rate2);
        }
        return GetGoodsRandom(money);//������߼۸�
    }
}
