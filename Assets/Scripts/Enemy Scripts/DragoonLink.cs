using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DragoonLink : Enemy
{
    public DragoonLink parent;
    public SpriteRenderer spriteRenderer;

    void Update()
    {
        if(parent != null)
        {
            rigidbody.velocity = (parent.transform.position + parent.transform.up) - transform.position;
            transform.rotation = Quaternion.Euler(rigidbody.velocity);
        }
        else
        {
            Destroy(this);
        }
    }
}
