using UnityEngine;


public class MoveableTreasure : Treasure
{
#pragma warning disable CS0649 // 从未对字段“MoveableTreasure.speed”赋值，字段将一直保持其默认值 0
    [SerializeField] float speed;
#pragma warning restore CS0649 // 从未对字段“MoveableTreasure.speed”赋值，字段将一直保持其默认值 0

    void Update()
    {
        if (speed != 0f)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

}
