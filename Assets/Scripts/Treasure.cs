using System;
using System.Collections.Generic;
using UnityEngine;


[Flags]
public enum TreasureID:uint
{
    MinGold = 0,
    MidGold = 1,
    BigGold = 2,
    MinStone=4,
    BigStone=8,
    Diamond = 16,
    Mouse = 32,
    DiamondMouse = 64,
    TNT=128,
    Bone=256,
    Chest = 512
}
public class Treasure : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] float mass;

    public int Score { get => score; }
    public float Mass { get => mass; }
    void OnTriggerEnter2D(Collider2D collision)
    {
        OnGrab();
    }

    protected virtual void OnGrab()
    {}
}
