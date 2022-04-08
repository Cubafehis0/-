using UnityEngine;


public enum MiningMachineStatus
{
    Idle=0,
    Drop=1,
    Drag=2
}


public class MiningMachine : MonoBehaviour
{
    [SerializeField] GameObject hook;
    [SerializeField] SpriteRenderer lineSpriteRender;
    [SerializeField] float dropSpeed = 1;
    [SerializeField] float dragSpeed = 1;
    [SerializeField] float rotateSpeed = 1;
    [SerializeField] float rotateAngleLimit = 80;
    [SerializeField] float maxLineLen;
    public float Speed
    {
        get
        {
            if (Status == MiningMachineStatus.Idle || Status == MiningMachineStatus.Drop) return 1;
            else return DragSpeed/dragSpeed;
        }
    }
    private float DragSpeed
    {
        get
        {
            //v0(1 - k * m)
            return dragSpeed * (1 - 0.01f * (DragTreasure?.Mass??0));
        }
    }
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
                Drop();
            else if (Status == MiningMachineStatus.Drag)
                Drag();
            if (lineSpriteRender.size.x > maxLineLen)
                Status = MiningMachineStatus.Drag;
        }
    }


    void Drop()
    {
        DragDrop(dropSpeed);
    }


    void Drag()
    {
        DragDrop(-DragSpeed);
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
        lineSpriteRender.size = new Vector2(lineSpriteRender.size.x + speed * Time.deltaTime, lineSpriteRender.size.y);
        hook.transform.position += hook.transform.right * speed * Time.deltaTime;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (Status == MiningMachineStatus.Drop)
        {
            if (collision.tag == "Treasures")
            {
                Treasure treasure = collision.transform.GetComponentInParent<Treasure>();
                float treasureHalfWidth = treasure.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 0.5f;

                treasure.transform.position = hook.transform.position + hook.transform.right * treasureHalfWidth;
                treasure.transform.SetParent(hook.transform);

                DragTreasure = treasure;
                Status = MiningMachineStatus.Drag;
            }
        }
    }
}
