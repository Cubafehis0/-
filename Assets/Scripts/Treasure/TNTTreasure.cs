using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TNTTreasure : Treasure
{
    [SerializeField] GameObject effect;
    [SerializeField] float explosionRadius;
    Animator animator;
    private void Start()
    {
    }
    public override void OnGrab()
    {
        base.OnGrab();
        GameObject go = GameObject.Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(go, 0.5f);
        SoundManager.Instance.PlayMusic("Explosion");
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        Destroy(gameObject);
        SetTag(gameObject, "Destory");
        foreach (Collider2D collider2D in collider2Ds)
        {
            GameObject hit=collider2D.gameObject;
            if(hit.tag== "Treasures")
            {
                Treasure treasure= hit.GetComponentInParent<Treasure>();
                if (treasure.gameObject == gameObject) continue;
                Destroy(treasure.gameObject);
                SetTag(treasure.gameObject, "Destory");
                if (treasure.ID == TreasureID.TNT)
                {
                    treasure.OnGrab();
                }
            }
        }
    }
    private void SetTag(GameObject go,string tag)
    {
        go.tag = tag;
        Transform[] children=go.GetComponentsInChildren<Transform>();
        foreach(Transform trans in children)
        {
            Debug.Log(trans.gameObject.name);
            trans.gameObject.tag = tag;
        }
    }
}
