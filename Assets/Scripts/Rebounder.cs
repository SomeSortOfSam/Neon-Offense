﻿using System.Collections;
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
        bool xCheck = cameraBounds.Contains(transform.position + bounds.center + (Vector3.right * bounds.extents.x * -Mathf.Sign(transform.position.x)));
        bool yCheck = cameraBounds.Contains(transform.position + bounds.center + (Vector3.up * bounds.extents.y * -Mathf.Sign(transform.position.y)));
        newPos.x = xCheck ? transform.position.x : -transform.position.x;
        newPos.y = yCheck ? transform.position.y : -transform.position.y;
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