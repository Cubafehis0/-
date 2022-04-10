using UnityEngine;


public class MoveableTreasure : Treasure
{
    [SerializeField] float speed;
    [SerializeField] float limit;
    bool right=false;

    void Update()
    {
        float x = transform.position.x;
        if (x < -limit)
        {
            right = true;
            transform.Rotate(new Vector3(0, 180, 0), Space.Self);
        }
        else if (x > limit)
        {
            right = false;
            transform.Rotate(new Vector3(0, 180, 0), Space.Self);
        }
        if(right)
            transform.Translate(Vector2.right * speed * Time.deltaTime,Space.World);
        else
            transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
    }
    public override void OnGrab()
    {
        base.OnGrab();
        speed = 0f;
    }
}
