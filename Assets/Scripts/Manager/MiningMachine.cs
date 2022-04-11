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
    [SerializeField] float maxLineLen = 8f;
    [SerializeField] float minLineLen = 0.5f;

    public static UnityEvent<Treasure> OnDrag2Hand = new UnityEvent<Treasure> { };
    public static float SpeedFactor = 1;

    private bool isRotateRight = true;
    private float hookLength;
    public bool hookTrigger = false;
    public bool reachItemTrigger = false;


    private float DragSpeed => dragSpeed * (1 - 0.01f * (DragTreasure?.Mass ?? 0));
    public float Speed
    {
        get
        {
            return DragSpeed / dragSpeed;
        }
    }


    public float HookLength
    {
        get => hookLength;
        set
        {
            hookLength = value;
            if (lineSpriteRender) lineSpriteRender.size = new Vector2(value, lineSpriteRender.size.y);
            if (hook) hook.transform.localPosition = value * Vector2.down;
        }
    }
    public Treasure DragTreasure { get; set; }
    public MiningMachineStatus Status { get; set; }
    public void UpdateProcess()
    {
        switch (Status)
        {
            case MiningMachineStatus.Idle:
                HookRotate((isRotateRight ? 1f : -1f) * Time.deltaTime * rotateSpeed);
                break;
            case MiningMachineStatus.Drop:
                HookMove(dropSpeed * SpeedFactor);
                break;
            case MiningMachineStatus.Drag:
                HookMove(-DragSpeed * SpeedFactor);
                break;
        }
    }

    public void UpdateStateMachine()
    {
        switch (Status)
        {
            case MiningMachineStatus.Idle:
                if (hookTrigger)
                {
                    Status = MiningMachineStatus.Drop;
                    hookTrigger = false;
                }
                break;
            case MiningMachineStatus.Drop:
                if (hookLength > maxLineLen)
                {
                    Status = MiningMachineStatus.Drag;
                }
                else if (reachItemTrigger)
                {
                    Status = MiningMachineStatus.Drag;
                    reachItemTrigger = false;
                }
                break;
            case MiningMachineStatus.Drag:
                if (hookLength < minLineLen)
                {
                    Status = MiningMachineStatus.Idle;
                    if (DragTreasure)
                    {
                        SoundManager.Instance.PlayMusic("Drag");
                        DragTreasure.OnDrag();
                        OnDrag2Hand?.Invoke(DragTreasure);
                        DragTreasure = null;
                    }
                }
                break;
        }
    }

    private void HookRotate(float delta)
    {
        transform.Rotate(new Vector3(0f, 0f, delta), Space.Self);
    }

    public void UpdateRotateStateMachine()
    {
        float angle = transform.eulerAngles.z;
        if (angle > 180 && angle <= 360)
            angle -= 360;
        if (isRotateRight)
        {
            if (angle > rotateAngleLimit)
            {
                isRotateRight = false;
            }
        }
        else
        {
            if (angle < -rotateAngleLimit)
            {
                isRotateRight = true;
            }
        }
    }

    private void HookMove(float speed)
    {
        hookLength += speed * Time.deltaTime;
    }

    public void StartHooking()
    {
        if (Status == MiningMachineStatus.Idle)
        {
            SoundManager.Instance.PlayMusic("Drop");
            hookTrigger = true;
        }
    }

    public bool TryUseBomb()
    {
        if (Status == MiningMachineStatus.Drag && PlayerDataMgr.Instance.ContainProp(PropID.Bomb) && DragTreasure != null)
        {
            UseBomb();
            return true;
        }
        return false;
    }

    public void UseBomb()
    {
        PlayerDataMgr.Instance.UseProp(PropID.Bomb, this);
    }

    private void OnEnable()
    {
        hookLength = minLineLen;
        Status = MiningMachineStatus.Idle;
    }

    private void Update()
    {
        if (!GameControl.Instance.IsGaming) return;
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartHooking();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TryUseBomb();
        }
        UpdateProcess();
        UpdateStateMachine();
        UpdateRotateStateMachine();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.Instance.PlayMusic("DragTreasure");
        if (Status == MiningMachineStatus.Drop)
        {
            if (collision.CompareTag("Treasures"))
            {
                Treasure treasure = collision.transform.GetComponentInParent<Treasure>();
                Grab(treasure);
            }
        }
    }

    public void Grab(Treasure treasure)
    {
        if (Status != MiningMachineStatus.Drop) return;
        reachItemTrigger = true;
        treasure.OnGrab();
        if (treasure.ID == TreasureID.TNT) return;
        float treasureHalfWidth = treasure.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 0.5f;
        treasure.transform.SetParent(hook.transform);
        treasure.transform.localPosition = Vector2.right * treasureHalfWidth;
        DragTreasure = treasure;
    }
}
