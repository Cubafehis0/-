using UnityEngine;



public enum TreasureID
{
    MinGold = 0,
    MidGold = 1,
    BigGold = 2,
    MinDiamond = 3,
    Chest = 7,
    SigleMouse = 32,
    MinStone = 12,
    DiamondMouse = 9,
    //   Chest = ,
    MidStone = 13,
}


public class Treasure : MonoBehaviour
{
#pragma warning disable CS0649 // 从未对字段“Treasure.score”赋值，字段将一直保持其默认值 0
    [SerializeField] int score;
#pragma warning restore CS0649 // 从未对字段“Treasure.score”赋值，字段将一直保持其默认值 0
#pragma warning disable CS0649 // 从未对字段“Treasure.mass”赋值，字段将一直保持其默认值 0
    [SerializeField] float mass;
#pragma warning restore CS0649 // 从未对字段“Treasure.mass”赋值，字段将一直保持其默认值 0

    public int GetScore()
    {
        return score;
    }


    public float GetMass()
    {
        return mass;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        onGrab();
    }


    protected virtual void onGrab()
    {

    }
}
