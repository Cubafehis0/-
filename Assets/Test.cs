using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private float timeScale=1;
    [SerializeField]
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
        Debug.Log(Time.deltaTime);
        if(transform.position.x>10) transform.Translate(new Vector3(-20,0,0));
        transform.Translate(new Vector3(speed*Time.deltaTime,0, 0));
    }
}
