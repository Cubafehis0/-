using System;
using UnityEngine;
using UnityEngine.Events;
public class MiningMachine : MonoBehaviour
{
    [SerializeField] GameObject hook;
    [SerializeField] SpriteRenderer lineSpriteRender;
    [SerializeField] float dropSpeed = 1;
    [SerializeField] float dragSpeed = 1;
    [SerializeField] float rotateSpeed = 1;
    [SerializeField] float rotateAngleLimit = 80;
    [SerializeField] float maxLineLen;
    [SerializeField] float minLineLen;
    [SerializeField] float hookLength=0.5f;
    public static UnityEvent<Treasure> OnDrag=new UnityEvent<Treasure> { };
    private static float speedFactor=1;
    public static void SpeedDouble()
    {
        speedFactor *= 2;
    }
    public static void SpeedHalf()
    {
        speedFactor /= 2;
    }
    public float Speed
    {
        get
        {
            if (Status == MiningMachineStatus.Idle || Status == MiningMachineStatus.Drop) return 1;
            else return DragSpeed/dragSpeed;
        }
    }
    private float DragSpeed=>dragSpeed* (1 - 0.01f * (DragTreasure?.Mass??0));
    bool isRotateRight = true;
    public Treasure DragTreasure { get; set; }
    public MiningMachineStatus Status { get; set; }
    public void UpdateProcess()
    {
        if (Status == MiningMachineStatus.Idle)
        {
            Rotate();
        }
        else
        {
            if (Status == MiningMachineStatus.Drop)
            {
                Drop();
                if (hookLength > maxLineLen)
                    Status = MiningMachineStatus.Drag;
            }
            else if (Status == MiningMachineStatus.Drag)
            {
                Drag();
                if(hookLength<minLineLen)
                {
                    Status = MiningMachineStatus.Idle;
                    if (DragTreasure)
                    {
                        SoundManager.Instance.PlayMusic("Drag");
                        DragTreasure.OnDrag();
                        OnDrag?.Invoke(DragTreasure);
                    }
                    DragTreasure = null;
                }
            }
        }
    }
    void Drop()
    {
        DragDrop(dropSpeed*speedFactor);
    }
    void Drag()
    {
        DragDrop(-DragSpeed*speedFactor);
    }

    void Rotate()
    {
        Vector3 position = transform.position;
        float angle = transform.eulerAngles.z;
        if (angle > 180 && angle <= 360)
            angle = angle - 360;

        if (isRotateRight)
        {
            if (angle < rotateAngleLimit)
                transform.RotateAround(transform.parent.position, Vector3.forward, Time.deltaTime * rotateSpeed);
            else
                isRotateRight = false;
        }
        else
        {
            if (angle > -rotateAngleLimit)
                transform.RotateAround(transform.parent.position, Vector3.forward, Time.deltaTime * -rotateSpeed);
            else
                isRotateRight = true;
        }
        transform.position = position;
    }


    void DragDrop(float speed)
    {
        hookLength += speed * Time.deltaTime;
        lineSpriteRender.size = new Vector2(hookLength, lineSpriteRender.size.y);
        hook.transform.localPosition =Vector2.down *hookLength;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.Instance.PlayMusic("DragTreasure");
        if (Status == MiningMachineStatus.Drop)
        {
            if (collision.tag == "Treasures")
            {
                Treasure treasure = collision.transform.GetComponentInParent<Treasure>();
                treasure.OnGrab();
                if(treasure.ID==TreasureID.TNT)
                {
                    Status = MiningMachineStatus.Drag;
                    return;
                }
                float treasureHalfWidth = treasure.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 0.5f;
                treasure.transform.position = hook.transform.position + hook.transform.right * treasureHalfWidth;
                treasure.transform.SetParent(hook.transform);
                DragTreasure = treasure;
                Status = MiningMachineStatus.Drag;
            }
        }
    }
}
