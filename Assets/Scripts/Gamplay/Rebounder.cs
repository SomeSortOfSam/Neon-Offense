using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Rebounder : MonoBehaviour
{
    new public BoxCollider2D collider;
    public virtual void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        Bounds cameraBounds = GamplayCamera.instance.CameraBounds;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Abs(transform.position.x + collider.size.x/2f) > cameraBounds.extents.x ? -transform.position.x : transform.position.x;
        newPos.y = Mathf.Abs(transform.position.y + collider.size.y/2f) > cameraBounds.extents.y ? -transform.position.y : transform.position.y;
        transform.position = newPos == (Vector2)transform.position ? transform.position : (Vector3)newPos;
    }
}
