using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rebounder : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        Bounds cameraBounds = GamplayCamera.instance.CameraBounds;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Abs(transform.position.x) > cameraBounds.extents.x ? -transform.position.x : transform.position.x;
        newPos.y = Mathf.Abs(transform.position.y) > cameraBounds.extents.y ? -transform.position.y : transform.position.y;
        transform.position = newPos == (Vector2)transform.position ? transform.position : (Vector3)newPos;
    }
}
