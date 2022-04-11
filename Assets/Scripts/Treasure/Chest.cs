using DG.Tweening;
using UnityEngine;


public class Chest : Treasure
{
    [SerializeField]
    Sprite[] sprites;
    [SerializeField]
    Vector2 endPos;
    public static float[] p1 = new float[] { 0.17f, 0.17f, 0.17f, 0.17f, 0.17f, 0.15f };
    public static float[] p2 = new float[] { 0.2f, 0.1f, 0.2f, 0.2f, 0.2f, 0.1f };
    public static float[] p = p1;
    public override void OnDrag()
    {
        int i = GetRandomIndex();
        PlayAnimation(i);
        GetRandomReward(i);
        Destroy(gameObject, 4f);
    }

    private void PlayAnimation(int i)
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        transform.parent = null;
        transform.position = endPos;
        transform.rotation = Quaternion.identity;
        sprite.DOFade(0, 2f)
                    .SetDelay(0f)
                    .OnComplete(() =>
                    {
                        if (i == 5) return;
                        SoundManager.Instance.PlayMusic("ChestOpen");
                        sprite.sprite = sprites[i];
                        sprite.DOFade(1, 1f);
                    });
    }

    public void GetRandomReward(int i)
    {
        PlayerDataMgr player = PlayerDataMgr.Instance;
        switch (i)
        {
            case 0:
                player.Score += 500;
                break;
            case 1:
                player.Score += 100;
                break;
            case 2:
                player.AddProps(PropID.StrengthWater);
                player.UseProp(PropID.StrengthWater);
                break;
            case 3:
                player.AddProps(PropID.StoneBook);
                player.UseProp(PropID.StoneBook);
                break;
            case 4:
                player.AddProps(PropID.GoodDiamond);
                player.UseProp(PropID.GoodDiamond);
                break;
        }
    }
    private int GetRandomIndex()
    {
        float v = Random.value;
        Debug.Log(v);
        for (int i = 0; i < p.Length; i++)
        {
            if (v < p[i])
            {
                return i;
            }
            else v -= p[i];
        }
        return 5;
    }
    public override void OnGrab()
    {
        base.OnGrab();
    }
}
