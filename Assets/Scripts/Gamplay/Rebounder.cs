using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebounder : MonoBehaviour
{
    public Bounds bounds;
    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        Bounds cameraBounds = GamplayCamera.instance.CameraBounds;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Abs(transform.position.x + bounds.extents.x) > cameraBounds.extents.x ? -transform.position.x : transform.position.x;
        newPos.y = Mathf.Abs(transform.position.y + bounds.extents.y) > cameraBounds.extents.y ? -transform.position.y : transform.position.y;
        transform.position = newPos == (Vector2)transform.position ? transform.position : (Vector3)newPos;
    }
    public virtual void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, bounds.size);
    }
}
