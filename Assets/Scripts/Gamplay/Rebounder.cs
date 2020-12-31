using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebounder : MonoBehaviour
{
    public Bounds bounds;
    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        Bounds cameraBounds = GamplayCamera.instance.CameraBounds;
        Vector2 newPos = new Vector2();
        bool xCheck = Mathf.Abs(transform.position.x + bounds.center.x + (bounds.extents.x * -Mathf.Sign(transform.position.x))) < cameraBounds.extents.x;
        bool yCheck = Mathf.Abs(transform.position.y + bounds.center.y + (bounds.extents.y * -Mathf.Sign(transform.position.y))) < cameraBounds.extents.y;
        newPos.x = xCheck ? transform.position.x : -transform.position.x + .1f * Mathf.Sign(transform.position.x);
        newPos.y = yCheck ? transform.position.y : -transform.position.y + .1f * Mathf.Sign(transform.position.y);
        if(newPos != (Vector2)transform.position)
        {
            transform.position = newPos;
        }

    }
    public virtual void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position + bounds.center, bounds.size);
    }
}
